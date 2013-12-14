using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EquipCheck
{
    /// <summary>
    /// Class for redirecting user after attempt to access unauthorized content.
    /// </summary>
    public partial class NotAuthorized : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Do nothing.
        }

        protected void OkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }
    }
}