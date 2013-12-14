using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EquipCheck
{
    // Class for handling application menu events.
    public partial class Site : System.Web.UI.MasterPage
    {
        // Method to setup the master page - not being used.
        protected void Page_Load(object sender, EventArgs e)
        {
            // Do nothing
        }

        // Class for redirecting the user to different web pages, based upon their menu selections.
        protected void EquipCheckMenu_MenuItemClick(object sender, MenuEventArgs e)
        {
            switch (e.Item.Text)
            {
                case "Welcome":
                    Response.Redirect("/Restricted/Welcome.aspx");
                    break;                
                case "Create":
                    Response.Redirect("/Restricted/CreateChecklist.aspx");
                    break;
                case "View":
                    Session["listSelection"] = "Camping Equipment";
                    Response.Redirect("/Restricted/ViewList.aspx");
                    break;
                case "Add":
                    Response.Redirect("/Restricted/AddItem.aspx");
                    break;
            }
        }
    }
}