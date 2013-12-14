using EquipCheck.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EquipCheck
{
    // Class for handling SelectItem.aspx events, and formatting and displaying Equipment List Items.
    public partial class SelectItem : System.Web.UI.Page
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
                getEquipmentListItems(user);
            }
            else
            {
                Response.Redirect("/NotAuthorized.aspx");
            }
        }

        // Method to get, format, and display the user's Equipment List Items.
        public void getEquipmentListItems(EquipCheckAppUser user)
        {
            List<EquipmentList> lists = user.AllEquipLists;
            List<EquipmentItem> items;
            StringBuilder equipItemDisplay = new StringBuilder();
            int itemNum = 0;

            for (int i = 0; i < lists.Count; i++)
            {
                items = lists[i].EquipListItems;
                equipItemDisplay.Append(lists[i].EquipListName);
                equipItemDisplay.Append(" - ");
                equipItemDisplay.Append(lists[i].EquipListDesc);
                equipItemDisplay.Append(":<br />");

                if (items != null && items.Count > 0)
                {

                    for (int j = 0; j < lists[i].EquipListItems.Count; j++)
                    {
                        itemNum++;
                        
                        if (j < lists[i].EquipListItems.Count - 1)
                        {
                            equipItemDisplay.Append("&nbsp&nbsp&nbsp&nbsp&nbsp");
                            equipItemDisplay.Append("<span id=\"item");
                            equipItemDisplay.Append(itemNum.ToString());
                            equipItemDisplay.Append("\" onclick=\"selectItem(item");
                            equipItemDisplay.Append(itemNum.ToString());
                            equipItemDisplay.Append(")\">");
                            equipItemDisplay.Append(items[j].EquipItemName);
                            equipItemDisplay.Append(" - ");
                            equipItemDisplay.Append(items[j].EquipItemDesc);
                            equipItemDisplay.Append("</span>");
                            equipItemDisplay.Append("<br />");
                        }
                        else
                        {
                            equipItemDisplay.Append("&nbsp&nbsp&nbsp&nbsp&nbsp");
                            equipItemDisplay.Append("<span id=\"item");
                            equipItemDisplay.Append(itemNum.ToString());
                            equipItemDisplay.Append("\" onclick=\"selectItem(item");
                            equipItemDisplay.Append(itemNum.ToString());
                            equipItemDisplay.Append(")\">");
                            equipItemDisplay.Append(items[j].EquipItemName);
                            equipItemDisplay.Append(" - ");
                            equipItemDisplay.Append(items[j].EquipItemDesc);
                            equipItemDisplay.Append("</span>");
                            equipItemDisplay.Append("<br /><br />");
                        }
                    }
                }
                else
                {
                    equipItemDisplay.Append("&nbsp&nbsp&nbsp&nbsp&nbspNo Items currently in the List.<br /><br />");
                }
            }

            SelectItemsMultilineLabel.Text = equipItemDisplay.ToString();
        }

        // Method to record and process the Equipment List Items selected by the user to include in the user's Checklist.
        // Also redirects user back to the CreateChecklist.aspx web page.
        protected void FinishedButton_Click(object sender, EventArgs e)
        {
            String allItems = Selected_items.Value;
            String[] items = allItems.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            String allItemsWithDescriptions = Selected_items_and_decriptions.Value;
            String[] itemsWithDescriptions = 
                allItemsWithDescriptions.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            Session["selectedItems"] = items;
            Session["selectedItemsWithDescriptions"] = itemsWithDescriptions;
            Response.Redirect("/Restricted/CreateChecklist.aspx");
        }
    }
}