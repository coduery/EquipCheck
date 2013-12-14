using System;
using System.Collections.Generic;
using System.Diagnostics;
using EquipCheck.Domain;
using EquipCheck.Services;

namespace EquipCheck.Business
{
    /// <summary>
    /// Class for defining a UserManager object to manage an EquipCheckAppUser.
    /// Design Pattern: Facade - hides the underlying complexity of the application from the Presentation layer.
    /// </summary>
    public class UserManager : SuperManager
    {
        /// <summary> Field to store instance of IUserSvc. </summary>
        private IUserSvc service = null;

        /// <summary>
        /// Method to create an EquipCheckAppUser.
        /// </summary>
        /// <param name="user"> Incoming parameter that specifies EquipCheckAppUser to create. </param>
        public EquipCheckAppUser CreateUser(EquipCheckAppUser user)
        {

            service = (IUserSvc)GetServiceFromFactory(typeof(IUserSvc).Name);

            if (service != null)
            {
                user = service.StoreEquipCheckAppUser(user);
            }
            else
            {
                user = null;
                Debug.WriteLine("Unable to create user.");
            }

            return user;
        }

        /// <summary>
        /// Method to retrieve a EquipCheckAppUser.
        /// </summary>
        /// <param name="user"> Incoming parameter that specifies the EquipCheckAppUser. </param>
        /// <returns> Returns an EquipCheckAppUser. </returns>
        public EquipCheckAppUser RetrieveUser(EquipCheckAppUser user)
        {
            service = (IUserSvc)GetServiceFromFactory(typeof(IUserSvc).Name);

            if (service != null)
            {
                return service.GetEquipCheckAppUser(user);
            }
            else
            {
                Debug.WriteLine("Unable to get user.");
                return null;
            }
        }

        public EquipCheckAppUser RetrieveLocalUser(EquipCheckAppUser user)
        {
            service = (IUserSvc)GetServiceFromFactory(typeof(IUserSvc).Name);

            if (service != null)
            {
                return service.GetLocalUser(user);
            }
            else
            {
                Debug.WriteLine("Unable to get user.");
                return null;
            }
        }
    }
}
