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
    // Class for handling Error.aspx events, and redirecting user to Login.aspx.
    public partial class Message : System.Web.UI.Page
    {
        // Method for setting up the page.
        protected void Page_Load(object sender, EventArgs e)
        {
            EquipCheckAppUser user = (EquipCheckAppUser)Session["user"];

            if (user == null && Session["message_type"] == null)
            {
                Response.Redirect("/Login.aspx");
            }
            else if (user != null && !Roles.IsUserInRole(user.Username, "Members")) 
            {
                Response.Redirect("/NotAuthorized.aspx");
            }
            else
            {
                PageHeaderLabel.Text = (String)Session["message"];
                PageNameLabel.Text = (String)Session["details"];
            }
        }

        // Method to redirect user after receiving successful confirmation message or error message.
        protected void OkButton_Click(object sender, EventArgs e)
        {
            switch (((String)Session["message_type"]))
            {
                case "register_success":
                    Response.Redirect("/Login.aspx");
                    break;
                case "item_success":
                    Response.Redirect("/Restricted/ViewList.aspx");
                    break;
                case "checklist_success":
                    Response.Redirect("/Restricted/Welcome.aspx");
                    break;
                case "login_error":
                    Response.Redirect("/Login.aspx");
                    break;
                case "register_error1":
                    Response.Redirect("/Registration.aspx");
                    break;
                case "register_error2":
                    Response.Redirect("/Registration.aspx");
                    break;
                case "item_error":
                    Response.Redirect("/Restricted/AddItem.aspx");
                    break;
                case "checklist_error":
                    Response.Redirect("/Restricted/CreateChecklist.aspx");
                    break;
                default:
                    Response.Redirect("/Login.aspx");
                    break;
            }
        }
    }
}