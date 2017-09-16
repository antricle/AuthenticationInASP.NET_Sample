using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuthenticationInASP.NET_Sample
{
    public partial class DataEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUsername.Text = HttpContext.Current.User.Identity.Name;

        }

        protected void hlSignOut_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Clear();
            Response.Redirect(Request.UrlReferrer.ToString());

        }
    }
}