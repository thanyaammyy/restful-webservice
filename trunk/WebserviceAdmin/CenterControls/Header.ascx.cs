using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebserviceAdmin.CenterControls
{
    public partial class Header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginKey"]==null)Response.Redirect("Login.aspx");
            if (Session["UserSession"]!=null)
                lbUsername.Text = Session["UserSession"].ToString();
        }

        protected void btnLogout_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Logout.aspx");
        }
    }
}