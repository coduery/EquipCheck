using EquipCheck.Business;
using EquipCheck.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EquipCheck.Presentation
{
    /// <summary>
    /// Class for creating a new user's default equipment lists.
    /// </summary>
    public class ListCreation
    {
        public static EquipCheckAppUser CreateLists(EquipCheckAppUser user)
        {
            EquipListManager listMgr = new EquipListManager();
            List<String> tempAllEquipListNames;

            // Create default equipment lists for user
            EquipmentList listCampEquip = new EquipmentList();
            EquipmentList listCampClothes = new EquipmentList();
            EquipmentList listCampFood = new EquipmentList();
            EquipmentList listCampMisc = new EquipmentList();

            listCampEquip.EquipListName = "Camping Equipment";
            listCampEquip.EquipListDesc = "All the camping supplies in our inventory";
            listCampClothes.EquipListName = "Camping Clothes";
            listCampClothes.EquipListDesc = "Clothes that we typically take camping";
            listCampFood.EquipListName = "Camping Food";
            listCampFood.EquipListDesc = "Food items we typically purchase for camping trips";
            listCampMisc.EquipListName = "Camping Miscellaneous";
            listCampMisc.EquipListDesc = "Miscellaneous camping items that don't fit into other lists";

            // Associate the Equipment Lists with the user
            List<EquipmentList> tempAllEquipLists = new List<EquipmentList>();
            EquipmentList[] equipmentLists = { listCampEquip, listCampClothes, listCampFood, listCampMisc };
            tempAllEquipLists.AddRange(equipmentLists);
            user.AllEquipLists = tempAllEquipLists;

            tempAllEquipListNames = new List<String>();

            for (int i = 0; i < equipmentLists.Length; i++)
            {
                listMgr.CreateEquipList(user, equipmentLists[i]);
                tempAllEquipListNames.Add(equipmentLists[i].EquipListName);
            }

            user.AllEquipListNames = tempAllEquipListNames;

            return user;
        }
    }
}