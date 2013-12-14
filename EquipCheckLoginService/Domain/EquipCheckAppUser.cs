using System;
using System.Runtime.Serialization;

namespace EquipCheckLoginService.Domain
{
    /// <summary>
    /// Class for defining an Equipment Checklist Application User.
    /// </summary>
    public class EquipCheckAppUser
    {
        /// <summary> Field for storing an Equipment Checklist Application user's username. </summary>
        private string username;

        /// <summary> Field for storing an Equipment Checklist Application user's password. </summary>
        private string password;
        
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
    }
}
