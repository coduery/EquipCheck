using System;
using System.Collections.Generic;
using EquipCheck.Domain;

namespace EquipCheck.Services
{
    /// <summary>
    /// Interface for defining an Equipment List Service.
    /// Design Pattern: Separated Interface - Interface that separates the service 
    /// implementation classes from the IService interface and the Factory class.
    /// </summary>
    public interface IEquipListSvc : IService
    {
        /// <summary> Method abstraction for adding an item to an existing EquipmentList. </summary>
        /// <param name="user"> Incoming parameter that specifies User of the EquipmentList. </param>
        /// <param name="list"> Specifies the EquipmentList. </param>
        /// <param name="item"> Specifies the EquipmentItem. </param>
        void AddItemToEquipmentList(EquipCheckAppUser user, EquipmentList list, EquipmentItem item);
        
        /// <summary> Method abstraction for storing an EquipmentList. </summary>
        /// <param name="user"> Incoming parameter that specifies User of the EquipmentList. </param>
        /// <param name="list"> Specifies the EquipmentList. </param>
        void StoreEquipmentList(EquipCheckAppUser user, EquipmentList list);

        /// <summary> Method abstraction for getting the user's equipment lists. </summary>
        /// <param name="user"> Incoming parameter that specifies user of the equipment lists. </param>
        /// <returns> Returns the user's equipment lists.  </returns>
        List <EquipmentList> GetEquipmentLists(EquipCheckAppUser user);
    }
}
