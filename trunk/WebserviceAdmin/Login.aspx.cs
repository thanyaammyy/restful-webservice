using System;
using System.Configuration;
using System.DirectoryServices;
using DataModelLib.Helper;
using DataModelLib.Page;

namespace WebserviceAdmin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            btnLogin.Enabled = true;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lbUserRequired.Visible = false;
            lbPwdRequired.Visible = false;
            lbError.Visible = false;
            Session["LoginSession"] = "False";
            Session["UserSession"] = "";
            var username = tbUsername.Text.ToLower();
            var password = tbPassword.Text;
            if (!(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)))
            {
                btnLogin.Enabled = false;
                var strAuthorize = ConfigurationManager.AppSettings["admin"];
                if(username.Contains(strAuthorize))
                {
                    if (AuthenticateActiveDirectory(username, password))
                    {
                        Session["LoginSession"] = "True";
                        Session["UserSession"] = username;
                        var strSharedSecret = ConfigurationManager.AppSettings["SharedSecret"];
                        var encryptUser = Encryption.EncryptStringAES(username, strSharedSecret);
                        
                        Session["loginKey"] = encryptUser;
                        Response.Redirect("Service.aspx");
                    }
                    else
                    {
                        btnLogin.Enabled = true;
                        lbError.Text = "Your login attempt was not successful. Please try again.";
                        lbError.Visible = true;
                        lbUserRequired.Visible = false;
                        lbPwdRequired.Visible = false;
                    }
                }
                else
                {
                    btnLogin.Enabled = true;
                    lbError.Text = "You are not authorized to access this page.";
                    lbError.Visible = true;
                    lbUserRequired.Visible = false;
                    lbPwdRequired.Visible = false;
                }
            }
            else
            {
                btnLogin.Enabled = true;
                lbUserRequired.Visible = true;
                lbPwdRequired.Visible = true;
                lbError.Text = "Please enter username and password.";
                lbError.Visible = true;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            tbPassword.Text = "";
            tbUsername.Text = "";
            lbError.Visible = false;
            lbPwdRequired.Visible = false;
            lbUserRequired.Visible = false;
        }

        public bool AuthenticateActiveDirectory(string userName, string password)
        {
            var strLdap = ConfigurationManager.AppSettings["ldap"];
            try
            {
                var entry = new DirectoryEntry(strLdap, userName, password);
                var nativeObject = entry.NativeObject;
                return true;
            }
            catch (DirectoryServicesCOMException)
            {
                return false;
            }
        }
    }
}