using EquipCheck.Domain;

using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

namespace EquipCheck.Services
{
    /// <summary>
    /// Class for implementing an CheckList Service.
    /// Design Pattern: Plugin - Implementation classes that plug into the Service Interfaces.
    /// </summary>
    public class CheckListSvcBinaryImpl : ICheckListSvc
    {
        /// <summary> Method for storing an CheckList. </summary>
        /// <param name="appUser"> Incoming parameter that specifies User of CheckList. </param>
        /// <param name="list"> Specifies the CheckList. </param>
        public void StoreCheckList(EquipCheckAppUser appUser, CheckList list)
        {
            using (var db = new EquipCheckEntities())
            {
                checklist checkList = new checklist()
                {
                    checklist_name = list.CheckListName,
                    checklist_description = list.CheckListDesc,
                    trip_name = list.TripName,
                    trip_description = list.TripDesc,
                    trip_date = list.TripDate,
                    checklist_summary = list.CheckListItemSummary,
                    user_id = appUser.UserID
                };

                db.checklists.Add(checkList);
                db.SaveChanges();
            }
        }

        /// <summary> Method for getting a user's checklists. </summary>
        /// <param name="user"> Incoming parameter that specifies checklists user. </param>
        /// <returns> Returns the checklists associated with the user.  </returns>
        public List<CheckList> GetCheckLists(EquipCheckAppUser appUser)
        {
            List<CheckList> checkLists = null;
            
            using (var db = new EquipCheckEntities())
            {
                var userID = appUser.UserID;

                var checklistResults = from checklists in db.checklists
                                       where checklists.user_id == userID
                                       select checklists;

                checkLists = new List<CheckList>();

                foreach (checklist checklist in checklistResults)
                {
                    CheckList checkList = new CheckList();
                    checkList.CheckListID = checklist.checklist_id;
                    checkList.CheckListName = checklist.checklist_name;
                    checkList.CheckListDesc = checklist.checklist_description;
                    checkList.TripName = checklist.trip_name;
                    checkList.TripDesc = checklist.trip_description;
                    checkList.TripDate = checklist.trip_date;
                    checkList.CheckListItemSummary = checklist.checklist_summary;
                    checkLists.Add(checkList);
                }

                appUser.AllCheckList = checkLists;
            }

            return checkLists;
        }
    }
}
