using EquipCheck.Business;
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
    // Class for handling Welcome.aspx events, and formatting and displaying Equipment Checklists and Equipment Lists.
    public partial class Welcome : System.Web.UI.Page
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
                PageNameLabel.Text = "Welcome " + user.Username + "!";

                Session["selectedItems"] = null;
                Session["selectedItemsWithDescriptions"] = null;

                // Display user's checklists and equipment lists
                displayChecklists(user);
                displayEquipmentLists(user);
            }
            else
            {
                Response.Redirect("/NotAuthorized.aspx");
            }
        }

        // Method to format and display user's checklist summary on Welcome Page.
        public void displayChecklists(EquipCheckAppUser user)
        {
            StringBuilder checkListSummary = new StringBuilder();

            if (user.AllCheckListNames.Count > 0)
            {
                for (int i = 0; i < user.AllCheckList.Count; i++)
                {
                    checkListSummary.Append(user.AllCheckList[i].CheckListName);
                    checkListSummary.Append(" - ");
                    checkListSummary.Append(user.AllCheckList[i].CheckListDesc);
                    checkListSummary.Append("\r\n\r\n");
                }
            }
            else
            {
                checkListSummary.Append("No Current Checklists!");
            }

            ChecklistsTextBox.Text = checkListSummary.ToString();
        }

        // Method to format and display user's equipment lists summary on Welcome Page.
        public void displayEquipmentLists(EquipCheckAppUser user)
        {
            List<EquipmentList> tempAllEquipLists = user.AllEquipLists;
            List<String> tempAllEquipListNames = user.AllEquipListNames;
            StringBuilder equipListSummary = new StringBuilder();

            for (int i = 0; i < user.AllEquipLists.Count; i++)
            {
                if (tempAllEquipLists[i].IsEquipListNullOrEmpty())
                {
                    equipListSummary.Append(tempAllEquipListNames[i]);
                    equipListSummary.Append("\r\n     Item Count: 0\r\n\r\n");
                }
                else
                {
                    equipListSummary.Append(tempAllEquipListNames[i]);
                    equipListSummary.Append("\r\n     Item Count: ");
                    equipListSummary.Append(tempAllEquipLists[i].EquipListItems.Count().ToString());
                    equipListSummary.Append("\r\n\r\n");
                }
            }

            EquipmentListsTextBox.Text = equipListSummary.ToString();
        }
    }
}