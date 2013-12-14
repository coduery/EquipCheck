using EquipCheck.Domain;
using EquipCheck.Services;

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EquipCheck.Business
{
    /// <summary>
    /// Class for defining a CheckListManager object to manage a CheckList.
    /// Design Pattern: Facade - hides the underlying complexity of the application from the Presentation layer.
    /// </summary>
    public class CheckListManager : SuperManager
    {
        /// <summary> Field to store instance of ICheckListSvc. </summary>
        private ICheckListSvc service = null;

        /// <summary>
        /// Method to create an CheckList.
        /// </summary>
        /// <param name="user"> Incoming parameter that specifies User of CheckList. </param>
        /// <param name="list"> Incoming parameter that specifies CheckList to create. </param>
        public void CreateCheckList(EquipCheckAppUser user, CheckList list)
        {
            service = (ICheckListSvc)GetServiceFromFactory(typeof(ICheckListSvc).Name);
            if (service != null)
            {
                service.StoreCheckList(user, list);
            }
            else
            {
                Debug.WriteLine("Unable to create list.");
            }
        }

        /// <summary>
        /// Method to retrieve a user's checklists.
        /// </summary>
        /// <param name="user"> Incoming parameter that specifies checklist user. </param>
        /// <returns> Returns user's checklists. </returns>
        public List<CheckList> RetrieveCheckLists(EquipCheckAppUser user)
        {
            service = (ICheckListSvc)GetServiceFromFactory(typeof(ICheckListSvc).Name);
            if (service != null)
            {
                return service.GetCheckLists(user);
            }
            else
            {
                Debug.WriteLine("Unable to get list.");
                return null;
            }
        }

        /// <summary>
        /// Method to return a user's checklists names.
        /// </summary>
        /// <param name="checkLists"> Incoming parameter that specifies the user's checklists. </param>
        /// <returns> Returns a list of checklist names. </returns>
        public List<String> getCheckListNames(List<CheckList> checkLists)
        {
            List<String> checkListNames = new List<String>();

            foreach (CheckList checkList in checkLists)
            {
                checkListNames.Add(checkList.CheckListName);
            }

            return checkListNames;
        }
    }
}
