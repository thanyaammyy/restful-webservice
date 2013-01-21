using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataModelLib.Page
{
    public static class DepartmentHelper
    {
        public static List<Department> ListDepartment()
        {
            var wdc = new WebserviceDataContext();
            return wdc.Departments.ToList();
        }

        public static void AddDepartment(Department department)
        {
            using (var hdc = new WebserviceDataContext())
            {
                hdc.Departments.InsertOnSubmit(new DataModelLib.Department
                {
                    DepartmentCode = department.DepartmentCode,
                    DepartmentName = department.DepartmentName,
                });

                try
                {
                    hdc.SubmitChanges();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2601 || ex.Number == 2627)
                    {
                        throw;
                    }
                }
            }
        }

        public static void UpdateDepartment(Department department)
        {
            using (var hdc = new WebserviceDataContext())
            {
                var prop = hdc.Departments.Single(item => item.DepartmentId == department.DepartmentId);

                prop.DepartmentName = department.DepartmentName;
                prop.DepartmentCode = department.DepartmentCode;

                try
                {
                    hdc.SubmitChanges();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2601 || ex.Number == 2627)
                    {
                        throw;
                    }
                }
            }
        }

        public static void DeleteDepartment(int departmentId)
        {
            using (var hdc = new WebserviceDataContext())
            {
                var department = hdc.Departments.Single(item => item.DepartmentId == departmentId);
                hdc.Departments.DeleteOnSubmit(department);
                try
                {
                    hdc.SubmitChanges();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2601 || ex.Number == 2627)
                    {
                        throw;
                    }
                }
            }
        }
    }
}
