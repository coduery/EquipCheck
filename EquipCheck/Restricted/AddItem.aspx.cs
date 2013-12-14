using EquipCheck.Business;
using EquipCheck.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EquipCheck
{
    // Class for handling AddItem.aspx events, and saving a new Equipment Item to a user's Equipment List.
    public partial class AddItem : System.Web.UI.Page
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
                ItemNameTextBox.Focus();

                Session["selectedItems"] = null;
                Session["selectedItemsWithDescriptions"] = null;

                if (Session["message_type"] != null && 
                    ((String)Session["message_type"]).Equals("item_error") && !IsPostBack)
                {
                    String[] itemEntries = (String[])Session["itemEntries"];
                    DropDownList.SelectedIndex = Convert.ToInt32(itemEntries[0]);
                    ItemNameTextBox.Text = itemEntries[1];
                    ItemDescriptionTextBox.Text = itemEntries[2];
                }
            }
            else
            {
                Response.Redirect("/NotAuthorized.aspx");
            }
        }

        // Method for saving a new Equipment Item to a user's Equipment List.
        protected void SaveItemButton_Click(object sender, EventArgs e)
        {
            EquipmentItem item = new EquipmentItem();
            item.EquipItemName = ItemNameTextBox.Text;
            item.EquipItemDesc = ItemDescriptionTextBox.Text;

            if (item.Validate() && !DropDownList.SelectedValue.Equals(""))
            {
                EquipCheckAppUser user = (EquipCheckAppUser)Session["user"];
                List<EquipmentList> lists = user.AllEquipLists;
                List<EquipmentItem> items = null;

                for (int i = 0; i < lists.Count; i++)
                {
                    if (lists[i].EquipListName.Equals(DropDownList.SelectedValue))
                    {
                        if (lists[i].EquipListItems != null)
                        {
                            items = lists[i].EquipListItems;
                        } else {
                            items = new List<EquipmentItem>();
                        }

                        EquipListManager listManager = new EquipListManager();
                        listManager.AddItemToList(user, lists[i], item);

                        items.Add(item);
                        lists[i].EquipListItems = items;
                        user.AllEquipLists = lists;

                        Session["user"] = user;
                        Session["listSelection"] = DropDownList.SelectedValue;
                        break;
                    }
                }

                Session["message_type"] = "item_success";
                Session["message"] = "Item Creation Successful.";
                Session["details"] = "Click OK to Continue!";

                Session["itemEntries"] = null;
            }
            else 
            {
                Session["message_type"] = "item_error";
                Session["message"] = "Item Entry Error.";
                Session["details"] = "All Entries Required!";

                String[] itemEntries = { DropDownList.SelectedIndex.ToString(), ItemNameTextBox.Text, ItemDescriptionTextBox.Text };
                Session["itemEntries"] = itemEntries;
            }

            Response.Redirect("/Restricted/Message.aspx");
        }
    }
}