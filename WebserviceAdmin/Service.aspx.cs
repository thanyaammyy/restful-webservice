using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataModelLib.Page;

namespace WebserviceAdmin
{
    public partial class Service : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                JqgridServiceBinding();
            }
        }

        protected void JqgridService_Init(object sender, EventArgs e)
        {
            JqgridServiceBinding();
        }

        protected void JqgridService_RowAdding(object sender, Trirand.Web.UI.WebControls.JQGridRowAddEventArgs e)
        {
            var serviceName = e.RowData["ServiceName"];
            var url = e.RowData["ServiceUrl"];
            var desc = e.RowData["Description"];
            var admin = Session["UserSession"].ToString();
            if (!(string.IsNullOrEmpty(url) || string.IsNullOrEmpty(serviceName)||string.IsNullOrEmpty(desc)))
            {
                var service = new DataModelLib.Service()
                {
                    ServiceName = serviceName,
                    ServiceURL = url,
                    UpdateUser = admin,
                    Description = desc
                };
                ServiceHelper.AddService(service);
            }
        }

        protected void JqgridService_RowDeleting(object sender, Trirand.Web.UI.WebControls.JQGridRowDeleteEventArgs e)
        {
            var serviceId = e.RowKey;
            if (string.IsNullOrEmpty(serviceId)) return;
            ServiceHelper.DeleteService(Convert.ToInt32(serviceId));
        }

        protected void JqgridService_RowEditing(object sender, Trirand.Web.UI.WebControls.JQGridRowEditEventArgs e)
        {
            var serviceName = e.RowData["ServiceName"];
            var url = e.RowData["ServiceUrl"];
            var desc = e.RowData["Description"];
            var admin = Session["UserSession"].ToString();
            var id = e.RowKey;
            if (!(string.IsNullOrEmpty(serviceName) || string.IsNullOrEmpty(url)||string.IsNullOrEmpty(desc)))
            {
                var Service = new DataModelLib.Service()
                {
                    ServiceId = Convert.ToInt32(id),
                    ServiceName = serviceName,
                    ServiceURL = url,
                    UpdateUser = admin,
                    Description = desc
                };
                ServiceHelper.UpdateService(Service);
            }
        }

        private void JqgridServiceBinding()
        {
            var services = ServiceHelper.ListService();
            JqgridService.DataSource = services;
            JqgridService.DataBind();
        }
    }
}