using EquipCheck.Business;
using EquipCheck.Domain;
using EquipCheck.Presentation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EquipCheck
{
    // Class for handling Login.aspx events.
    public partial class Login : System.Web.UI.Page
    {
        // Method to setup the page.
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["user"] = null;
        }

        // Method to handle user login validation, obtain user 
        // information, and redirect client following login attempt.
        protected void EquipCheckLoginCtrl_Authenticate(object sender, AuthenticateEventArgs e)
        {
            EquipCheckAppUser user = new EquipCheckAppUser();
            user.Username = EquipCheckLoginCtrl.UserName;
            user.Password = EquipCheckLoginCtrl.Password;

            UserManager userMgr = new UserManager();
            EquipCheckAppUser userAtServer = userMgr.RetrieveUser(user);

            if (userAtServer != null)
            {
                e.Authenticated = true;

                EquipCheckAppUser userLocal = userMgr.RetrieveLocalUser(userAtServer);

                if (userLocal == null)
                {
                    userLocal = userMgr.CreateUser(userAtServer);
                    userLocal = ListCreation.CreateLists(userLocal);
                }
                
                // Get user's checklists
                CheckListManager checkListManager = new CheckListManager();
                List<CheckList> checkLists = checkListManager.RetrieveCheckLists(userLocal);
                List<String> checkListNames = checkListManager.getCheckListNames(checkLists);

                userLocal.AllCheckList = checkLists;
                userLocal.AllCheckListNames = checkListNames;

                // Get user's equipment lists
                EquipListManager equipListManager = new EquipListManager();
                List<EquipmentList> equipLists = equipListManager.RetrieveEquipLists(userLocal);

                if (equipLists == null || equipLists.Count == 0)
                {
                    userLocal = ListCreation.CreateLists(userLocal);
                }
                else
                {
                    List<String> equipListNames = equipListManager.getEquipmentListNames(equipLists);
                    userLocal.AllEquipLists = equipLists;
                    userLocal.AllEquipListNames = equipListNames;
                }

                Session["user"] = userLocal;

                Response.Redirect("/Restricted/Welcome.aspx");
            }
            else
            {
                e.Authenticated = false;

                Session["user"] = null;
                Session["message_type"] = "login_error";
                Session["message"] = "Login Error.";
                Session["details"] = "User Credentials Invalid.";
                Response.Redirect("/Restricted/Message.aspx");
            }
        }

        // Method for handling Registration button click events
        protected void RegistrationButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Registration.aspx");
        }
    }
}