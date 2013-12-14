using System;
using System.Text;
using System.Collections.Generic;

namespace EquipCheck.Domain
{
    /// <summary>
    /// Class for creating a new Equipment Item.
    /// Design Pattern: Value Object - an object which contains field values, 
    /// the state of the field values, and methods for analyzing or comparing the state of the field values.
    /// </summary>
    [Serializable]
    public class EquipmentItem : IComparer<EquipmentItem>
    {
        /// <summary> Field for storing an Equipment Item ID. </summary>
        private int equipItemID;
        
        /// <summary> Field for storing an Equipment Item name. </summary>
        private String equipItemName;

        /// <summary> Field for storing an Equipment Item description. </summary>
        private String equipItemDesc;

        /// <summary> The EquipItemID property designates the Equipment Item ID. </summary>
        /// <value> The EquipItemID property gets/sets the value of the EquipItemID. </value>
        public int EquipItemID
        {
            set
            {
                equipItemID = value;
            }
            get
            {
                return equipItemID;
            }
        }
        
        /// <summary> The EquipItemName property designates the Equipment Item name. </summary>
        /// <value> The EquipItemName property gets/sets the value of the EquipItemName String. </value>
        public String EquipItemName
        {
            set
            {
                equipItemName = value;
            }
            get
            {
                return equipItemName;
            }
        }

        /// <summary> The EquipItemDesc property designates the Equipment Item description. </summary>
        /// <value> The EquipListDesc property gets/sets the value of the EquipItemDesc StringBuilder. </value>
        public String EquipItemDesc
        {
            set
            {
                equipItemDesc = value;
            }
            get
            {
                return equipItemDesc;
            }
        }

        /// <summary>
        /// Method facilitating the comparison and sorting of a list of Equipment Items.
        /// </summary>
        /// <param name="item1"> Incoming parameter of Equipment Item to compare. </param>
        /// <param name="item2"> Incoming parameter of another Equipment Item to compare.  </param>
        /// <returns> Returns an int value indicating whether one item is equal, less, or more than the other. </returns>
        public int Compare(EquipmentItem item1, EquipmentItem item2)
        {
            return string.Compare(item1.EquipItemName, item2.EquipItemName);
        }

        /// <summary> Method override to check if two Equipment Items are the same or not. </summary>
        /// <param name="obj"> Specifies the EquipmentItem object to compare to this EquipmentItem. </param>
        /// <returns> Returns false if the two Equipment Items are not the same; otherwise returns true.  </returns>
        public override bool Equals(Object obj)
        {
            if ((EquipmentItem)obj != null)
            {
                EquipmentItem item = (EquipmentItem)obj;
                if (!equipItemName.Equals(item.EquipItemName)) return false;
                if (!equipItemDesc.Equals(item.EquipItemDesc)) return false;
                return true;
            }
            return false;
        }

        /// <summary> Method override to check the hash code of a EquipmentItem. </summary>
        /// <returns> Returns an integer with the Equipment Item object hashcode. </returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary> Method override to display the Equipment Item field values. </summary>
        /// <returns> Returns a string that displays the Equipment Item field values. </returns>
        public override String ToString()
        {
            string tempString = "Equipment Item Fields:  " +
                                "\r\nEquipment Item Name: " + equipItemName +
                                "\r\nEquipment Item Description: " + equipItemDesc;
            return tempString;
        }

        /// <summary> Method to check the validity of the Equipment Item name and description. </summary>
        /// <returns> Returns false if Equipment Item name or description is null or empty string; otherwise returns true. </returns>
        public bool Validate()
        {
            if (String.IsNullOrEmpty(equipItemName)) return false;
            if (String.IsNullOrEmpty(equipItemDesc)) return false;
            return true;
        }
    }
}
