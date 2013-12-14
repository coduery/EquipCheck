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
    // Class for handling CreateChecklist.aspx events, and formatting and displaying checklist items selected by the user.
    public partial class CreateChecklist : System.Web.UI.Page
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
                ChecklistNameTextBox.Focus();

                Session["itemEntries"] = null;

                if (!IsPostBack)
                {
                    if (Session["checkListEntries"] != null)
                    {
                        String[] checkListEntries = (String[])Session["checkListEntries"];
                        ChecklistNameTextBox.Text = checkListEntries[0];
                        ChecklistDescriptionTextBox.Text = checkListEntries[1];
                        TripNameTextBox.Text = checkListEntries[2];
                        TripDescriptionTextBox.Text = checkListEntries[3];
                        TripDateTextBox.Text = checkListEntries[4];
                    }
                }

                if (Session["selectedItems"] != null)
                {
                    getSelectedItems(user);

                    if (ChecklistItemsTextBox.Text.Equals(""))
                    {
                        ChecklistItemsTextBox.Text = "No Items Currently Selected";
                    }
                }
                else
                {
                    ChecklistItemsTextBox.Text = "No Items Currently Selected";
                }
            }
            else
            {
                Response.Redirect("/NotAuthorized.aspx");
            }
        }

        // Method to get, format, and display items the user has selected for a checklist.
        private void getSelectedItems(EquipCheckAppUser user)
        {
            List<string> tempCheckListItems = new List<string>((String[])Session["selectedItems"]);
            List<string> tempCheckListItemsWithDescription = 
                new List<string>((String[])Session["selectedItemsWithDescriptions"]);
            tempCheckListItems.Sort();
            tempCheckListItemsWithDescription.Sort();
            StringBuilder checkListItems = new StringBuilder();
            List<EquipmentList> tempAllEquipmentLists = user.AllEquipLists;

            foreach (EquipmentList equipList in tempAllEquipmentLists)
            {
                List<EquipmentItem> tempEquipmentItems = equipList.EquipListItems;
                List<string> tempEquipmentItemNames = new List<string>();

                if (tempEquipmentItems != null)
                {
                    for (int i = 0; i < tempEquipmentItems.Count; i++)
                    {
                        tempEquipmentItemNames.Add(tempEquipmentItems[i].EquipItemName);
                    }
                }

                bool firstPass = true;
                for (int i = 0; i < tempCheckListItems.Count; i++)
                {

                    if (tempEquipmentItemNames.Contains(tempCheckListItems[i]))
                    {
                        if (firstPass)
                        {
                            checkListItems.Append(equipList.EquipListName);
                            checkListItems.Append(":\r\n");
                            firstPass = false;
                        }
                        checkListItems.Append("     ");
                        checkListItems.Append(tempCheckListItemsWithDescription[i]);
                        checkListItems.Append("\r\n");
                    }
                }

                if (!firstPass)
                {
                    checkListItems.Append("\r\n");
                }

            }
            ChecklistItemsTextBox.Text = checkListItems.ToString();
        }

        // Method to redirect user to the SelectItem.aspx web page, and save CreateChecklist.aspx entries (if any).
        protected void SelectItemsButton_Click(object sender, EventArgs e)
        {
            saveChecklistEntries();
            Response.Redirect("/Restricted/SelectItem.aspx");
        }

        // Method to save the user's Equipment Checklist.
        protected void SaveChecklistButton_Click(object sender, EventArgs e)
        {
            CheckList checkList = new CheckList();
            checkList.CheckListName = ChecklistNameTextBox.Text;
            checkList.CheckListDesc = ChecklistDescriptionTextBox.Text;
            checkList.TripName = TripNameTextBox.Text;
            checkList.TripDesc = TripDescriptionTextBox.Text;
            checkList.TripDate = TripDateTextBox.Text;
            checkList.CheckListItemSummary = ChecklistItemsTextBox.Text;

            if (checkList.Validate())
            {
                EquipCheckAppUser user = (EquipCheckAppUser)Session["user"];
                List<CheckList> checkLists = user.AllCheckList;

                CheckListManager checkListManager = new CheckListManager();
                checkListManager.CreateCheckList(user, checkList);

                checkLists.Add(checkList);
                user.AllCheckList = checkLists;

                List<String> checkListNames = user.AllCheckListNames;
                checkListNames.Add(checkList.CheckListName);
                user.AllCheckListNames = checkListNames;

                Session["user"] = user;
                Session["checkListEntries"] = null;
                Session["selectedItems"] = null;
                Session["selectedItemsWithDescriptions"] = null;

                Session["message_type"] = "checklist_success";
                Session["message"] = "Checklist Creation Successful.";
                Session["details"] = "Click OK to Continue!";
            }
            else
            {
                saveChecklistEntries();
                Session["message_type"] = "checklist_error";
                Session["message"] = "Checklist Entry Error.";
                Session["details"] = "Checklist Name and Description are Required!";
            }

            Response.Redirect("/Restricted/Message.aspx");
        }

        // Method to save entries in web page textboxes
        private void saveChecklistEntries()
        {
            String[] checkListEntries = { ChecklistNameTextBox.Text, ChecklistDescriptionTextBox.Text, 
                    TripNameTextBox.Text, TripDescriptionTextBox.Text, TripDateTextBox.Text };
            Session["checkListEntries"] = checkListEntries;
        }
    }
}