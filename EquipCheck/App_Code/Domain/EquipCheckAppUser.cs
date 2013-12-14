using System;
using System.Collections.Generic;

namespace EquipCheck.Domain
{
    /// <summary>
    /// Class for creating a new Equipment Checklist Application User.
    /// Design Pattern: Value Object - an object which contains field values, 
    /// the state of the field values, and methods for analyzing or comparing the state of the field values.
    /// </summary>
    [Serializable]
    public class EquipCheckAppUser
    {
        /// <summary> Field for storing an Equipment Checklist Application user's ID. </summary>
        private int userID;
        
        /// <summary> Field for storing an Equipment Checklist Application user's username. </summary>
        private string username;

        /// <summary> Field for storing an Equipment Checklist Application user's password. </summary>
        private string password;

        /// <summary> Field for storing an Equipment Checklist Application user's list of equipment lists. </summary>
        [NonSerialized()] private List<EquipmentList> allEquipLists = new List<EquipmentList>();

        /// <summary> Field for storing an Equipment Checklist Application user's list of equipment lists names. </summary>
        private List<String> allEquipListNames;

        /// <summary> Field for storing an Equipment Checklist Application user's list of equipment Checklists. </summary>
        [NonSerialized()] private List<CheckList> allCheckList;

        /// <summary> Field for storing an Equipment Checklist Application user's list of equipment Checklists names. </summary>
        private List<String> allCheckListNames;

        /// <summary> The UserID property designates the user's ID. </summary>
        /// <value> The UserID property gets/sets the value of the UserID. </value>
        public int UserID
        {
            set
            {
                userID = value;
            }
            get
            {
                return userID;
            }
        }
        
        /// <summary> The Username property designates the user's username. </summary>
        /// <value> The Username property gets/sets the value of the Username String. </value>
        public String Username
        {
            set
            {
                username = value;
            }
            get
            {
                return username;
            }
        }

        /// <summary> The Password property designates the user's password. </summary>
        /// <value> The Password property gets/sets the value of the Password String. </value>
        public String Password
        {
            set
            {
                password = value;
            }
            get
            {
                return password;
            }
        }

        /// <summary> The AllEquipLists property designates all of the user's equipment lists. </summary>
        /// <value> The AllEquipLists property gets/sets the value of the AllEquipLists field. </value>
        public List<EquipmentList> AllEquipLists
        {
            set
            {
                allEquipLists = value;
            }
            get
            {
                return allEquipLists;
            }
        }

        /// <summary> The AllEquipListNames property designates all of the user's equipment list names. </summary>
        /// <value> The AllEquipLists property gets/sets the value of the AllEquipListNames field. </value>
        public List<String> AllEquipListNames
        {
            get { return allEquipListNames; }
            set { allEquipListNames = value; }
        }

        /// <summary> The AllCheckList property designates all of the user's equipment checklists. </summary>
        /// <value> The AllCheckList property gets/sets the value of the allCheckList field. </value>
        public List<CheckList> AllCheckList
        {
            get { return allCheckList; }
            set { allCheckList = value; }
        }

        /// <summary> The AllCheckListNames property designates all of the user's equipment checklist names. </summary>
        /// <value> The AllCheckListNames property gets/sets the value of the allCheckListNames field. </value>
        public List<String> AllCheckListNames
        {
            get { return allCheckListNames; }
            set { allCheckListNames = value; }
        }

        /// <summary> Method to determine if the user has any Equipment Lists. </summary>
        /// <returns> Returns true if the user does not have any Equipment Lists; otherwise returns false. </returns>
        public bool IsAllEquipListsNullOrEmpty()
        {
            if (allEquipLists.Count == 0) return true;
            return false;
        }

        /// <summary> Method to determine if an Equipment List Name exists already. </summary>
        /// <param name="equipListName"> Specifies the Equipment List Name. </param>
        /// <returns> Returns true if the Equipment List Name exists already; otherwise returns false. </returns>
        public bool DoesEquipListExist(string equipListName)
        {
            foreach (EquipmentList equipList in allEquipLists){
                if (equipList.EquipListName == equipListName)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary> Method override to check if two Equipment Checklist Application user's are the same user or not. </summary>
        /// <param name="obj"> Specifies the EquipCheckAppUser object to compare to this EquipCheckAppUser. </param>
        /// <returns> Returns false if the two user's username and password are not the same; otherwise returns true.  </returns>
        public override bool Equals(Object obj)
        {
            if ((EquipCheckAppUser)obj != null)
            {
                EquipCheckAppUser user = (EquipCheckAppUser)obj;
                if (!username.Equals(user.Username)) return false;
                if (!password.Equals(user.Password)) return false;
                return true;
            }
            return false;
        }

        /// <summary> Method override to check the hash code of the Equipment Checklist Application User. </summary>
        /// <returns> Returns an integer with the EquipCheckAppUser object hashcode. </returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary> Method override to display the EquipCheckAppUser field values. </summary>
        /// <returns> Returns a string that displays the EquipCheckAppUser field values. </returns>
        public override String ToString()
        {
            string tempString = "Equipment Checklist Application User Fields:  " + 
                                "\r\nUsername: " + username + 
                                "\r\nPassword: " + password;
            return tempString;
        }
        
        /// <summary> Method to check the validity of the user's username and password. </summary>
        /// <returns> Returns false if username/password is null or empty string; otherwise returns true. </returns>
        public bool Validate()
        {
            if (String.IsNullOrEmpty(username)) return false;
            if (String.IsNullOrEmpty(password)) return false;
            return true;
        }
    }
}
