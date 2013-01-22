using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataModelLib.Page
{
    public static class UserHelper
    {
        public static List<DataModelLib.Helper.User> ListUser()
        {
            var mdc = new WebserviceDataContext();
            List<DataModelLib.Helper.User> listUser= null;
            listUser = (from user in mdc.Users
                        join property in mdc.Properties on user.PropertyId equals property.PropertyId
                        join department in mdc.Departments on user.DepartmentId equals department.DepartmentId
                        orderby property.PropertyCode, department.DepartmentCode
                        select new DataModelLib.Helper.User()
                                   {
                                       UserId = user.UserId,
                                       Username = user.Username,
                                       Password = user.Password,
                                       IP = user.IP,
                                       StatusLabel = user.StatusLabel,
                                       DepartmentCode = department.DepartmentCode,
                                       PropertyCode = property.PropertyCode
                                   }).ToList();
            
            return listUser;
        }

        public static void AddUser(User user)
        {
            using (var hdc = new WebserviceDataContext())
            {
                hdc.Users.InsertOnSubmit(new DataModelLib.User
                {
                    Username = user.Username,
                    Password = user.Password,
                    IP = user.IP,
                    PropertyId = user.PropertyId,
                    DepartmentId = user.DepartmentId,
                    UpdateDateTime = DateTime.Now,
                    Status = user.Status
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

        public static void UpdateUser(User user)
        {
            using (var hdc = new WebserviceDataContext())
            {
                var getUser = hdc.Users.Single(item => item.UserId == user.UserId);

                    getUser.Username = user.Username;
                    getUser.Password = user.Password;
                    getUser.IP = user.IP;
                    getUser.PropertyId = user.PropertyId;
                    getUser.DepartmentId = user.DepartmentId;
                    getUser.UpdateDateTime = DateTime.Now;
                    getUser.Status = user.Status;

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

        public static void DeleteUser(int userId)
        {
            using (var hdc = new WebserviceDataContext())
            {
                var user = hdc.Users.Single(item => item.UserId == userId);
                hdc.Users.DeleteOnSubmit(user);
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

        public static bool IsUserExist(string username)
        {
            var user = false;
            using (var hdc = new WebserviceDataContext())
            {
                var count = hdc.Users.Count(item => item.Username == username);
                if (count != 0)
                {
                    user = true;
                }
            }
            return user;
        }
    }
}
