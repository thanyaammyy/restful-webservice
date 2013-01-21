using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataModelLib.Page;

namespace WebserviceAdmin
{
    public partial class Property : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                JqgridPropertyBinding();
            }
        }

        private void JqgridPropertyBinding()
        {
            var companyList = PropertyHelper.ListProperty();
            JqgridProperty.DataSource = companyList;
            JqgridProperty.DataBind();
        }

        protected void JqgridProperty_RowAdding(object sender, Trirand.Web.UI.WebControls.JQGridRowAddEventArgs e)
        {
            var name = e.RowData["PropertyName"];
            var code = e.RowData["PropertyCode"];
            if (!(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(code)))
            {

                var property = new DataModelLib.Property()
                {
                    PropertyCode = e.RowData["PropertyCode"],
                    PropertyName = e.RowData["PropertyName"]
                };
                PropertyHelper.AddProperty(property);
            }
        }

        protected void JqgridProperty_RowEditing(object sender, Trirand.Web.UI.WebControls.JQGridRowEditEventArgs e)
        {
            var name = e.RowData["PropertyName"];
            var code = e.RowData["PropertyCode"];
            var id = e.RowKey;
            if (!(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(code)))
            {
                var property = new DataModelLib.Property()
                {
                    PropertyId = Convert.ToInt32(id),
                    PropertyName = e.RowData["PropertyName"],
                    PropertyCode = e.RowData["PropertyCode"]
                };
                PropertyHelper.UpdateProperty(property);
            }
        }

        protected void JqgridProperty_RowDeleting(object sender, Trirand.Web.UI.WebControls.JQGridRowDeleteEventArgs e)
        {
            var id = e.RowKey;
            if (string.IsNullOrEmpty(id)) return;
            PropertyHelper.DeleteProperty(Convert.ToInt32(id));
        }

        protected void JqgridProperty_Init(object sender, EventArgs e)
        {
            JqgridPropertyBinding();
        }
    }
}