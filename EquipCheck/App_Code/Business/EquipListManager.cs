using EquipCheck.Domain;
using EquipCheck.Services;

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EquipCheck.Business
{
    /// <summary>
    /// Class for defining a EquipListManager object to manage an EquipmentList.
    /// Design Pattern: Facade - hides the underlying complexity of the application from the Presentation layer.
    /// </summary>
    public class EquipListManager : SuperManager
    {
        /// <summary> Field to store instance of IEquipListSvc. </summary>
        private IEquipListSvc service = null;
        
        /// <summary>
        /// Method to add an Equipment Item to an Equipment List.
        /// </summary>
        /// <param name="user"> Incoming parameter that specifies the user. </param>
        /// <param name="list"> Incoming parameter that specifies list to add item to. </param>
        /// <param name="item"> Incoming parameter that specifies item to add to a list. </param>
        public void AddItemToList(EquipCheckAppUser user, EquipmentList list, EquipmentItem item)
        {
            service = (IEquipListSvc)GetServiceFromFactory(typeof(IEquipListSvc).Name);

            if (service != null)
            {
                service.AddItemToEquipmentList(user, list, item);
            }
            else
            {
                Debug.WriteLine("Unable to add item to list.");
            }
        }

        /// <summary>
        /// Method to create an EquipmentList.
        /// </summary>
        /// <param name="user"> Incoming parameter that specifies the user of EquipmentList. </param>
        /// <param name="list"> Incoming parameter that specifies EquipmentList to create. </param>
        public void CreateEquipList(EquipCheckAppUser user, EquipmentList list)
        {
            service = (IEquipListSvc)GetServiceFromFactory(typeof(IEquipListSvc).Name);
            if (service != null)
            {
                service.StoreEquipmentList(user, list);
            }
            else
            {
                Debug.WriteLine("Unable to create list.");
            }
        }

        /// <summary>
        /// Method to retrieve a user's equipment lists.
        /// </summary>
        /// <param name="user"> Incoming parameter that specifies the user of the equipment lists. </param>
        /// <returns> Returns the user's equipment lists. </returns>
        public List<EquipmentList> RetrieveEquipLists(EquipCheckAppUser user)
        {
            service = (IEquipListSvc)GetServiceFromFactory(typeof(IEquipListSvc).Name);

            if (service != null)
            {
                return service.GetEquipmentLists(user);
            }
            else
            {
                Debug.WriteLine("Unable to get list.");
                return null;
            }
        }

        /// <summary>
        /// Method to return a user's equipment lists names. 
        /// </summary>
        /// <param name="equipLists"> Incoming parameter that specifies the user's equipment lists. </param>
        /// <returns> Returns a list of equipment list names. </returns>
        public List<String> getEquipmentListNames(List<EquipmentList> equipLists)
        {
            List<String> equipListNames = new List<String>();

            foreach (EquipmentList list in equipLists)
            {
                equipListNames.Add(list.EquipListName);
            }

            return equipListNames;
        }
    }
}
