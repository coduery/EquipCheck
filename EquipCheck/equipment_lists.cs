//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EquipCheck
{
    using System;
    using System.Collections.Generic;
    
    public partial class equipment_lists
    {
        public equipment_lists()
        {
            this.equipment_items = new HashSet<equipment_items>();
        }
    
        public int list_id { get; set; }
        public string list_name { get; set; }
        public string list_description { get; set; }
        public int user_id { get; set; }
    
        public virtual app_users app_users { get; set; }
        public virtual ICollection<equipment_items> equipment_items { get; set; }
    }
}