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

        public static int Authentication(string username, string password)
        {
            var userId = 0;

            using (var hdc = new WebserviceDataContext())
            {
                var count = hdc.Users.Count(item => item.Username.Equals(username)&&item.Password.Equals(password));
                if (count != 0)
                {
                    var user = hdc.Users.Single(item => item.Username.Equals(username) && item.Password.Equals(password));
                    userId = user.UserId;
                }
            }
            return userId;
        }
    }
}
