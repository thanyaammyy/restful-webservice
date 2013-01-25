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
            var userId = e.RowData["UserId"];
            var serviceId = e.RowData["ServiceId"];
            var ips = e.RowData["Ips"];
            var status = e.RowData["StatusLabel"];
            var admin = Session["UserSession"].ToString();
            if (!(string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(status) || string.IsNullOrEmpty(ips) || string.IsNullOrEmpty(serviceId)))
            {

                var userService = new DataModelLib.UserService()
                {
                    UserId = Convert.ToInt32(userId),
                    ServiceId = Convert.ToInt32(serviceId),
                    Ips = ips,
                    UpdateUser = admin
                };
                UserServiceHelper.AddUserService(userService);
            }
        }

        protected void JqgridUserService_RowEditing(object sender, Trirand.Web.UI.WebControls.JQGridRowEditEventArgs e)
        {
            var userId = e.RowData["UserId"];
            var serviceId = e.RowData["ServiceId"];
            var ips = e.RowData["Ips"];
            var status = e.RowData["StatusLabel"];
            var admin = Session["UserSession"].ToString();
            var id = e.RowKey;
            if (!(string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(status) || string.IsNullOrEmpty(ips) || string.IsNullOrEmpty(serviceId)))
            {

                var userService = new DataModelLib.UserService()
                {
                    Id = Convert.ToInt32(id),
                    UserId = Convert.ToInt32(userId),
                    ServiceId = Convert.ToInt32(serviceId),
                    Ips = ips,
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