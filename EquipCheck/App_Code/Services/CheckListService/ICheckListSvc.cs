using System;
using System.Collections.Generic;
using EquipCheck.Domain;

namespace EquipCheck.Services
{
    /// <summary>
    /// Interface for defining an CheckList Service.
    /// Design Pattern: Separated Interface - Interface that separates the service 
    /// implementation classes from the IService interface and the Factory class.
    /// </summary>
    public interface ICheckListSvc : IService
    {        
        /// <summary> Method abstraction for storing an CheckList. </summary>
        /// <param name="user"> Incoming parameter that specifies User of CheckList. </param>
        /// <param name="list"> Specifies the CheckList. </param>
        void StoreCheckList(EquipCheckAppUser user, CheckList list);

        /// <summary> Method abstraction for getting a user's checklists. </summary>
        /// <param name="user"> Incoming parameter that specifies checklists user. </param>
        /// <returns> Returns the checklists associated with the user.  </returns>
        List<CheckList> GetCheckLists(EquipCheckAppUser user);
    }
}
