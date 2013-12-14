using EquipCheck.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Diagnostics;

namespace EquipCheck
{
    // Class for handling ViewList.aspx events, and formatting and displaying existing Equipment Lists.
    public partial class ViewList : System.Web.UI.Page
    {
        // Method to setup the page for the user.
        protected void Page_Load(object sender, EventArgs e)
        {
            EquipCheckAppUser user = (EquipCheckAppUser)Session["user"];

            if (user == null)
            {
                Response.Redirect("/Login.aspx");
            }
            else if (Roles.IsUserInRole(user.Username, "Members"))
            {
                Session["selectedItems"] = null;
                Session["selectedItemsWithDescriptions"] = null;
                Session["itemEntries"] = null;

                if (!IsPostBack)
                {
                    DropDownList.SelectedValue = (String)Session["listSelection"];
                }
                getEquipmentListItems(user);
            }
            else
            {
                Response.Redirect("/NotAuthorized.aspx");
            }
        }

        // Method to get, format, and display the user's Equipment Lists.
        public void getEquipmentListItems(EquipCheckAppUser user)
        {
            List<EquipmentList> lists = user.AllEquipLists;
            List<EquipmentItem> items = null;
            for (int i = 0; i < lists.Count; i++) 
            {
                if (lists[i].EquipListName.Equals(DropDownList.SelectedValue))
                {
                    items = lists[i].EquipListItems;
                    break;
                }
            }

            StringBuilder equipmentListItemSummary = new StringBuilder();

            if (items != null)
            {
                equipmentListItemSummary.Append("Summary of Items in List:\r\nNumber of Items: ");
                equipmentListItemSummary.Append(items.Count);
                equipmentListItemSummary.Append("\r\n\r\n");
            }
            else
            {
                equipmentListItemSummary.Append("Summary of Items in List:\r\nNumber of Items: 0\r\n\r\n");
            }

            if (items != null)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    equipmentListItemSummary.Append(items[i].EquipItemName);
                    equipmentListItemSummary.Append(" - ");
                    equipmentListItemSummary.Append(items[i].EquipItemDesc);
                    equipmentListItemSummary.Append("\r\n\r\n");
                }
            }
            else
            {
                equipmentListItemSummary.Append("No Items currently in the List.");
            }

            ViewListTextBox.Text = equipmentListItemSummary.ToString();
        }

        // Method for processing the display of different Equipment Lists that are selected by the user from the drop down list.
        protected void DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            EquipCheckAppUser user = (EquipCheckAppUser)Session["user"];
            Session["listSelection"] = DropDownList.SelectedValue;
            getEquipmentListItems(user);
        }
    }
}