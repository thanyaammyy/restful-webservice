using System;
using DataModelLib.Page;

namespace WebserviceAdmin
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                JqgridUserBinding();
            }
        }

        protected void JqgridUser_Init(object sender, EventArgs e)
        {
            JqgridUserBinding();
        }

        protected void JqgridUser_RowAdding(object sender, Trirand.Web.UI.WebControls.JQGridRowAddEventArgs e)
        {
            var password = e.RowData["Password"];
            var username = e.RowData["Username"];
            var description = e.RowData["Description"];
            var admin = Session["UserSession"].ToString();
            if (!(string.IsNullOrEmpty(password) || string.IsNullOrEmpty(username)))
            {
                var user = new DataModelLib.User()
                {
                    
                    Username = username,
                    Password = password,
                    Description = description,
                    UpdateUser = admin
                };
                if (UserHelper.IsUserExist(user.Username)) return;
                UserHelper.AddUser(user);
            }
        }

        protected void JqgridUser_RowDeleting(object sender, Trirand.Web.UI.WebControls.JQGridRowDeleteEventArgs e)
        {
            var userId = e.RowKey;
            if (string.IsNullOrEmpty(userId)) return;
            UserHelper.DeleteUser(Convert.ToInt32(userId));
        }

        protected void JqgridUser_RowEditing(object sender, Trirand.Web.UI.WebControls.JQGridRowEditEventArgs e)
        {
            var password = e.RowData["Password"];
            var username = e.RowData["Username"];
            var description = e.RowData["Description"];
            var id = e.RowKey;
            var admin = Session["UserSession"].ToString();
            if (!(string.IsNullOrEmpty(password) || string.IsNullOrEmpty(username)))
            {
                var user = new DataModelLib.User()
                {
                    UserId = Convert.ToInt32(id),
                    Username = username,
                    Password = password,
                    Description = description,
                    UpdateUser = admin
                };
                UserHelper.UpdateUser(user);
            }
        }

        private void JqgridUserBinding()
        {
            var users = UserHelper.ListUser();
            JqgridUser.DataSource = users;
            JqgridUser.DataBind();
        }
    }
}