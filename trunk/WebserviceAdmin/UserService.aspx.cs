using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataModelLib.Page;

namespace WebserviceAdmin
{
    public partial class UserService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                JqgridUserServiceBinding();
            }
        }

        private void JqgridUserServiceBinding()
        {
            var companyList = UserServiceHelper.ListUserService();
            JqgridUserService.DataSource = companyList;
            JqgridUserService.DataBind();
        }

        protected void JqgridUserService_RowAdding(object sender, Trirand.Web.UI.WebControls.JQGridRowAddEventArgs e)
        {
            var user = e.RowData["Username"];
            var service = e.RowData["ServiceName"];
            var ips = e.RowData["Ips"];
            var status = e.RowData["StatusLabel"];
            var admin = Session["UserSession"].ToString();
            if (!(string.IsNullOrEmpty(user) || string.IsNullOrEmpty(status) || string.IsNullOrEmpty(ips) || string.IsNullOrEmpty(service)))
            {

                var userService = new DataModelLib.UserService()
                {
                    UserId = Convert.ToInt32(user),
                    ServiceId = Convert.ToInt32(service),
                    Ips = ips,
                    Status = Convert.ToInt32(status),
                    UpdateUser = admin
                };
                UserServiceHelper.AddUserService(userService);
            }
        }

        protected void JqgridUserService_RowEditing(object sender, Trirand.Web.UI.WebControls.JQGridRowEditEventArgs e)
        {
            var user = e.RowData["Username"];
            var service = e.RowData["ServiceName"];
            var ips = e.RowData["Ips"];
            var status = e.RowData["StatusLabel"];
            var admin = Session["UserSession"].ToString();
            var id = e.RowKey;
            if (!(string.IsNullOrEmpty(user) || string.IsNullOrEmpty(status) || string.IsNullOrEmpty(ips) || string.IsNullOrEmpty(service)))
            {

                var userService = new DataModelLib.UserService()
                {
                    Id = Convert.ToInt32(id),
                    UserId = Convert.ToInt32(user),
                    ServiceId = Convert.ToInt32(service),
                    Ips = ips,
                    Status = Convert.ToInt32(status),
                    UpdateUser = admin
                };
                UserServiceHelper.UpdateUserService(userService);
            }
        }

        protected void JqgridUserService_RowDeleting(object sender, Trirand.Web.UI.WebControls.JQGridRowDeleteEventArgs e)
        {
            var id = e.RowKey;
            if (string.IsNullOrEmpty(id)) return;
            UserServiceHelper.DeleteUserService(Convert.ToInt32(id));
        }

        protected void JqgridUserService_Init(object sender, EventArgs e)
        {
            JqgridUserServiceBinding();
        }
    }
}