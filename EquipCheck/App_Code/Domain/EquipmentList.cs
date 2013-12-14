using System;
using System.Collections.Generic;

namespace EquipCheck.Domain
{
    /// <summary>
    /// Class for creating a new Equipment List.
    /// Design Pattern: Value Object - an object which contains field values, 
    /// the state of the field values, and methods for analyzing or comparing the state of the field values.
    /// </summary>
    [Serializable]
    public class EquipmentList
    {
        /// <summary> Field for storing an Equipment List ID. </summary>
        private int equipListID;
        
        /// <summary> Field for storing an Equipment List name. </summary>
        private string equipListName;

        /// <summary> Field for storing an Equipment List description. </summary>
        private String equipListDesc;

        /// <summary> Field for storing an Equipment List of equipment items. </summary>
        private List<EquipmentItem> equipListItems;

        /// <summary> The EquipListID property designates the Equipment List ID. </summary>
        /// <value> The EquipListID property gets/sets the value of the equipListID. </value>
        public int EquipListID
        {
            set
            {
                equipListID = value;
            }
            get
            {
                return equipListID;
            }
        }
        
        /// <summary> The EquipListName property designates the Equipment List name. </summary>
        /// <value> The EquipListName property gets/sets the value of the equipListName String. </value>
        public String EquipListName
        {
            set
            {
                equipListName = value;
            }
            get
            {
                return equipListName;
            }
        }

        /// <summary> The EquipListDesc property designates the Equipment List description. </summary>
        /// <value> The EquipListDesc property gets/sets the value of the EquipListDesc StringBuilder. </value>
        public String EquipListDesc
        {
            set
            {
                equipListDesc = value;
            }
            get
            {
                return equipListDesc;
            }
        }

        /// <summary> The EquipListItems property designates a user's equipment item list. </summary>
        /// <value> The EquipListItems property gets/sets the value of the EquipListItems List field. </value>
        public List<EquipmentItem> EquipListItems
        {
            set
            {
                equipListItems = value;
            }
            get
            {
                return equipListItems;
            }
        }

        /// <summary> Method to determine if a user's Equipment List is Empty. </summary>
        /// <returns> Returns true if a user's Equipment List is Empty; otherwise returns false. </returns>
        public bool IsEquipListNullOrEmpty()
        {
            if (equipListItems == null || equipListItems.Count == 0) return true;
            return false;
        }

        /// <summary> Method to determine if an Equipment Item Name exists already. </summary>
        /// <param name="equipItemName"> Specifies the Equipment Item Name. </param>
        /// <returns> Returns true if the Equipment Item Name exists already; otherwise returns false. </returns>
        public bool DoesEquipItemExist(string equipItemName)
        {
            foreach (EquipmentItem equipItem in equipListItems)
            {
                if (equipItem.EquipItemName == equipItemName)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary> Method override to check if two Equipment Lists are the same or not. </summary>
        /// <param name="obj"> Specifies the EquipmentList object to compare to this EquipmentList. </param>
        /// <returns> Returns false if the two Equipment Lists are not the same; otherwise returns true.  </returns>
        public override bool Equals(Object obj)
        {
            if ((EquipmentList)obj != null)
            {
                EquipmentList list = (EquipmentList)obj;
                if (!equipListName.Equals(list.EquipListName)) return false;
                if (!equipListDesc.Equals(list.EquipListDesc)) return false;
                return true;
            }
            return false;
        }

        /// <summary> Method override to check the hash code of a EquipmentList. </summary>
        /// <returns> Returns an integer with the Equipment List object hashcode. </returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary> Method override to display the Equipment List field values. </summary>
        /// <returns> Returns a string that displays the Equipment List field values. </returns>
        public override String ToString()
        {
            string tempString = "Equipment List Fields:  " +
                                "\r\nEquipment List Name: " + equipListName +
                                "\r\nEquipment List Description: " + equipListDesc;
            return tempString;
        }

        /// <summary> Method to check the validity of the Equipment List name and description. </summary>
        /// <returns> Returns false if Equipment List name or description is null or empty string; otherwise returns true. </returns>
        public bool Validate()
        {
            if (String.IsNullOrEmpty(equipListName)) return false;
            if (String.IsNullOrEmpty(equipListDesc.ToString())) return false;
            return true;
        }
    }
}
