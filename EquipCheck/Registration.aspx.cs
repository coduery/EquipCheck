using EquipCheck.Business;
using EquipCheck.Domain;
using EquipCheck.Presentation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EquipCheck
{
    // Class for handling Registration.aspx events.
    public partial class Registration : System.Web.UI.Page
    {
        // Method to setup the page.
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["user"] = null;

            String[] roles = Roles.GetAllRoles();
            Boolean doesRoleExist = false;
            foreach (String role in roles)
            {
                if (role.Equals("Members"))
                {
                    doesRoleExist = true;
                }
            }

            if (!doesRoleExist)
            {
                Roles.CreateRole("Members");
                Roles.CreateRole("NonMembers");
            }
        }

        // Method to associate a newly created user with the current session
        protected void CreateUserWizard_CreatingUser(object sender, LoginCancelEventArgs e)
        {
            EquipCheckAppUser user = new EquipCheckAppUser();
            user.Username = CreateUserWizard.UserName;
            user.Password = CreateUserWizard.Password;
            Session["user"] = user;
        }


        // Method to initialize a new user account
        protected void CreateUserWizard_CreatedUser(object sender, EventArgs e)
        {
            EquipCheckAppUser userAtServer = (EquipCheckAppUser)Session["user"];
            UserManager userManager = new UserManager();
            userAtServer = userManager.RetrieveUser(userAtServer);

            Roles.AddUserToRole(userAtServer.Username, "Members");

            EquipCheckAppUser userLocal = null;

            if (userAtServer != null)
            {
                userLocal = userManager.CreateUser(userAtServer);
            }

            if (userLocal != null)
            {
                userLocal = ListCreation.CreateLists(userLocal);
            }
        }

        protected void CreateUserWizard_ContinueButtonClick(object sender, EventArgs e)
        {
            Response.Redirect("/Login.aspx");
        }
    }
}