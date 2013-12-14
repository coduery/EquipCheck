using System;
using System.Diagnostics;
using EquipCheck.Services;

namespace EquipCheck.Business
{
    /// <summary>
    /// Class for defining a base Manager for manager subclasses.
    /// Design Pattern: Layer Supertype - base class that provides common functionality to subclasses in the Business layer.
    /// </summary>
    public abstract class SuperManager
    {

        /// <summary> Field to store instance of IService. </summary>
        private IService service = null;

        /// <summary>
        /// Method to get an IService service.
        /// </summary>
        /// <returns> Returns IService service. </returns>
        protected IService GetServiceFromFactory(String iServName)
        {
            Factory factory = Factory.GetInstance();

            try
            {
                service = factory.GetService(iServName);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Unable to establish service: " + e.Message);
            }
            return service;
        }
    }
}
