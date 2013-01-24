using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using DataModelLib;

namespace DataModelLib.Page
{
    public static class UserHelper
    {
        public static List<User> ListUser()
        {
            var wdc = new WebserviceDataContext();
            return wdc.Users.ToList();
        }

        public static void AddUser(User user)
        {
            using (var hdc = new WebserviceDataContext())
            {
                hdc.Users.InsertOnSubmit(new User
                {
                    Username = user.Username,
                    Password = user.Password,
                    Description = user.Description,
                    UpdateUser = user.UpdateUser,
                    UpdateDateTime = DateTime.Now
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
                var usr = hdc.Users.Single(item => item.UserId == user.UserId);

                usr.Username = user.Username;
                usr.Password = user.Password;
                usr.Description = user.Description;
                usr.UpdateUser = user.UpdateUser;
                usr.UpdateDateTime = DateTime.Now;

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

        public static void DeleteUser(int UserId)
        {
            using (var hdc = new WebserviceDataContext())
            {
                var User = hdc.Users.Single(item => item.UserId == UserId);
                hdc.Users.DeleteOnSubmit(User);
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
