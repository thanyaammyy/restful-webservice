using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataModelLib.Page;

namespace WebserviceAdmin
{
    public partial class Department : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                JqgridDeptBinding();
            }
        }

        private void JqgridDeptBinding()
        {
            var companyList = DepartmentHelper.ListDepartment();
            JqgridDept.DataSource = companyList;
            JqgridDept.DataBind();
        }

        protected void JqgridDept_RowAdding(object sender, Trirand.Web.UI.WebControls.JQGridRowAddEventArgs e)
        {
            var name = e.RowData["DepartmentName"];
            var code = e.RowData["DepartmentCode"];
            if (!(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(code)))
            {

                var department = new DataModelLib.Department()
                {
                    DepartmentCode = e.RowData["DepartmentCode"],
                    DepartmentName = e.RowData["DepartmentName"]
                };
                DepartmentHelper.AddDepartment(department);
            }
        }

        protected void JqgridDept_RowEditing(object sender, Trirand.Web.UI.WebControls.JQGridRowEditEventArgs e)
        {
            var name = e.RowData["DepartmentName"];
            var code = e.RowData["DepartmentCode"];
            var id = e.RowKey;
            if (!(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(code)))
            {
                var department = new DataModelLib.Department()
                {
                    DepartmentId = Convert.ToInt32(id),
                    DepartmentName = e.RowData["DepartmentName"],
                    DepartmentCode = e.RowData["DepartmentCode"]
                };
                DepartmentHelper.UpdateDepartment(department);
            }
        }

        protected void JqgridDept_RowDeleting(object sender, Trirand.Web.UI.WebControls.JQGridRowDeleteEventArgs e)
        {
            var id = e.RowKey;
            if (string.IsNullOrEmpty(id)) return;
            DepartmentHelper.DeleteDepartment(Convert.ToInt32(id));
        }

        protected void JqgridDept_Init(object sender, EventArgs e)
        {
            JqgridDeptBinding();
        }
    }
}