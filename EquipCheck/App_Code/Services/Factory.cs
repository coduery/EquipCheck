using System;
using System.Configuration;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Web.Configuration;

namespace EquipCheck.Services
{
    /// <summary>
    /// Class for defining a Factory to create service implementations for the Equipment Checklist Application.
    /// Design Pattern: Factory - Serves up Services and hides the details from the Business layer by interacting with IService interface.
    /// Design Pattern: Singleton - Used to prevent more than one instance of the Factory being created at same time.
    /// </summary>
    public class Factory
    {
        /// <summary>
        /// Field to store a static instance of Factory.
        /// Design Pattern: Singleton (one part of three).
        /// </summary>
        private static Factory factory = new Factory();

        /// <summary>
        /// Default Constructor declared as private.
        /// Design Pattern: Singleton (one part of three).
        /// </summary>
        private Factory(){}

        /// <summary>
        /// Method to get an instance of Factory.
        /// Design Pattern: Singleton (one part of three).
        /// </summary>
        /// <returns> Returns an instance of Factory. </returns>
        public static Factory GetInstance() { return factory; }

        /// <summary>
        /// Method to retrieve a service implementation.
        /// </summary>
        /// <param name="servName"> Incoming parameter that specifies the name of the service interface to retrieve. </param>
        /// <returns> Returns service implementation as an IService type. </returns>
        public IService GetService(String servName)
        {
            Type type;
            Object obj = null;

            try
            {
                type = Type.GetType(GetImplName(servName));
                obj = Activator.CreateInstance(type);
            }
            catch (Exception e)
            {
                Debug.WriteLine("An Exception occurred in Factory: {0}", e.Message);
                throw e;
            }
            return (IService)obj;
        }

        /// <summary>
        /// Method to look up service implementation based upon service interface name.
        /// </summary>
        /// <param name="servName"> Incoming parameter that specifies the name of the service interface to retrieve. </param>
        /// <returns> Returns a string representing name of the service implementation. </returns>
        private String GetImplName(string servName)
        {
            //Configuration webConfig = WebConfigurationManager.OpenWebConfiguration("/");
            Configuration webConfig = WebConfigurationManager.OpenWebConfiguration(System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
            KeyValueConfigurationElement setting = webConfig.AppSettings.Settings[servName];

            return setting.Value;
        }
    }
}
