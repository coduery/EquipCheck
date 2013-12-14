using System;
using System.Text;

namespace EquipCheck.Domain
{
    /// <summary>
    /// Class for creating a new CheckList.
    /// Design Pattern: Value Object - an object which contains field values, 
    /// the state of the field values, and methods for analyzing or comparing the state of the field values.
    /// </summary>
    [Serializable]
    public class CheckList
    {
        /// <summary> Property that designates the Checklist ID. </summary>
        /// <value> The CheckListID property gets/sets the value of CheckListID. </value>
        public int CheckListID { get; set; }
        
        /// <summary> Property that designates the Checklist Name. </summary>
        /// <value> The CheckListName property gets/sets the value of CheckListName. </value>
        public String CheckListName { get; set; }

        /// <summary> Property that designates the Checklist description. </summary>
        /// <value> The CheckListDesc property gets/sets the value of CheckListDesc. </value>
        public String CheckListDesc { get; set; }

        /// <summary> Property that designates the Checklist Trip Name. </summary>
        /// <value> The TripName property gets/sets the value of TripName. </value>
        public String TripName { get; set; }

        /// <summary> Property that designates the Checklist Trip Description. </summary>
        /// <value> The TripDesc property gets/sets the value of TripDesc. </value>
        public String TripDesc { get; set; }

        /// <summary> Property that designates the Trip Date. </summary>
        /// <value> The TripDate property gets/sets the value of TripDate. </value>
        public String TripDate { get; set; }

        /// <summary> Property that designates the summary of items selected for a given checklist. </summary>
        /// <value> The CheckListItemSummary property gets/sets summary of items selected for a given checklist. </value>
        public String CheckListItemSummary { get; set; }

        /// <summary> Method override to check if two Equipment Items are the same or not. </summary>
        /// <param name="obj"> Specifies the CheckList object to compare to this CheckList. </param>
        /// <returns> Returns false if the two Checklists are not the same; otherwise returns true.  </returns>
        public override bool Equals(Object obj)
        {
            if((CheckList)obj != null){
                CheckList checkList = (CheckList)obj;
                if(!CheckListName.Equals(checkList.CheckListName)) return false;
                if (!CheckListDesc.ToString().Equals(checkList.CheckListDesc.ToString())) return false;
                if(!TripName.Equals(checkList.TripName)) return false;
                if (!TripDesc.ToString().Equals(checkList.TripDesc.ToString())) return false;
                if(!TripDate.Equals(checkList.TripDate)) return false;
                return true;
            }
            return false;
        }

        /// <summary> Method override to check the hash code of a CheckList. </summary>
        /// <returns> Returns an integer with the CheckList object hashcode. </returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary> Method override to display the CheckList field values. </summary>
        /// <returns> Returns a string that displays the CheckList field values. </returns>
        public override String ToString()
        {
            string tempString = "Checklist Fields:  " +
                    "\r\nChecklist Name: " + CheckListName +
                    "\r\nChecklist Description: " + CheckListDesc +
                    "\r\nTrip Name: " + TripName +
                    "\r\nTrip Description: " + TripDesc +
                    "\r\nTrip Date: " + TripDate;
            return tempString;
        }

        /// <summary> Method to check the validity of the Checklist Item name and description. </summary>
        /// <returns> Returns false if Checklist name or description is null or empty string; otherwise returns true. </returns>
        public bool Validate()
        {
            if (String.IsNullOrEmpty(CheckListName)) return false;
            if (String.IsNullOrEmpty(CheckListDesc)) return false;
            return true;
        }
    }
}
