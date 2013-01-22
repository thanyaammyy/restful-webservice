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
            var status = e.RowData["StatusLabel"];
            var property = e.RowData["PropertyCode"];
            var department = e.RowData["DepartmentCode"];
            var ip = e.RowData["IP"];
            var password = e.RowData["Password"];
            var username = e.RowData["Username"];
            var admin = Session["UserSession"].ToString();
            if (!(string.IsNullOrEmpty(status) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(property) || string.IsNullOrEmpty(department)))
            {
                var user = new DataModelLib.User()
                {
                    PropertyId = Convert.ToInt32(property),
                    DepartmentId = Convert.ToInt32(department),
                    IP = ip,
                    Status = Convert.ToInt32(status),
                    Username = username,
                    Password = password,
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
            var status = e.RowData["StatusLabel"];
            var property = e.RowData["PropertyCode"];
            var department = e.RowData["DepartmentCode"];
            var ip = e.RowData["IP"];
            var password = e.RowData["Password"];
            var username = e.RowData["Username"];
            var id = e.RowKey;
            var admin = Session["UserSession"].ToString();
            if (!(string.IsNullOrEmpty(status) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(property) || string.IsNullOrEmpty(department)))
            {
                var user = new DataModelLib.User()
                {
                    UserId = Convert.ToInt32(id),
                    PropertyId = Convert.ToInt32(property),
                    DepartmentId = Convert.ToInt32(department),
                    IP = ip,
                    Status = Convert.ToInt32(status),
                    Username = username,
                    Password = password,
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