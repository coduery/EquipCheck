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
    
    public partial class equipment_items
    {
        public int item_id { get; set; }
        public string item_name { get; set; }
        public string item_description { get; set; }
        public int list_id { get; set; }
    
        public virtual equipment_lists equipment_lists { get; set; }
    }
}