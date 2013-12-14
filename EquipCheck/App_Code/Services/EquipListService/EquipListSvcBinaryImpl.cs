using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using EquipCheck.Domain;

namespace EquipCheck.Services
{
    /// <summary>
    /// Class for implementing an Equipment List Service.
    /// Design Pattern: Plugin - Implementation classes that plug into the Service Interfaces.
    /// </summary>
    public class EquipListSvcBinaryImpl : IEquipListSvc
    {
        /// <summary> Method for adding an item to an existing EquipmentList. </summary>
        /// <param name="user"> Incoming parameter that specifies User of the EquipmentList. </param>
        /// <param name="list"> Specifies the EquipmentList. </param>
        /// <param name="item"> Specifies the EquipmentItem. </param>
        public void AddItemToEquipmentList(EquipCheckAppUser user, EquipmentList list, EquipmentItem item)
        {
            using(var db = new EquipCheckEntities()) {

                equipment_items equipItem = new equipment_items()
                {
                    item_name = item.EquipItemName,
                    item_description = item.EquipItemDesc,
                    list_id = list.EquipListID
                };

                db.equipment_items.Add(equipItem);
                db.SaveChanges();
            } 
        }
        
        /// <summary> Method for storing an EquipmentList. </summary>
        /// <param name="user"> Incoming parameter that specifies User of the EquipmentList. </param>
        /// <param name="list"> Specifies the EquipmentList. </param>
        public void StoreEquipmentList(EquipCheckAppUser user, EquipmentList list)
        {
            using (var db = new EquipCheckEntities())
            {
                equipment_lists equipList = new equipment_lists()
                {
                    list_name = list.EquipListName,
                    list_description = list.EquipListDesc,
                    user_id = user.UserID
                };

                db.equipment_lists.Add(equipList);
                db.SaveChanges();
            }
        }

        /// <summary> Method for getting the user's equipment lists. </summary>
        /// <param name="user"> Incoming parameter that specifes user of the equipment lists. </param>
        /// <returns> Returns the user's equipment lists.  </returns>
        public List<EquipmentList> GetEquipmentLists(EquipCheckAppUser appUser)
        {
            List<EquipmentList> lists = null;

            using (var db = new EquipCheckEntities())
            {
                var userID = appUser.UserID;
                
                var equiplistResults = from equiplists in db.equipment_lists
                                       where equiplists.user_id == userID
                                       select equiplists;

                lists = new List<EquipmentList>();

                foreach (equipment_lists equiplist in equiplistResults)
                {

                    EquipmentList list = new EquipmentList();
                    list.EquipListID = equiplist.list_id;
                    list.EquipListName = equiplist.list_name;
                    list.EquipListDesc = equiplist.list_description;

                    var listID = list.EquipListID;

                    var equipitemResults = from equipitems in db.equipment_items
                                           where equipitems.list_id == listID
                                           select equipitems;

                    List<EquipmentItem> items = new List<EquipmentItem>();

                    foreach (equipment_items equipitem in equipitemResults)
                    {

                        EquipmentItem item = new EquipmentItem();
                        item.EquipItemID = equipitem.item_id;
                        item.EquipItemName = equipitem.item_name;
                        item.EquipItemDesc = equipitem.item_description;
                        items.Add(item);
                    }

                    list.EquipListItems = items;
                    lists.Add(list);
                }

                appUser.AllEquipLists = lists;
            }

            return lists;
        }
    }
}
