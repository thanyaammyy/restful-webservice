using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataModelLib.Page
{
    public static class UserServiceServiceHelper
    {
        public static List<DataModelLib.Helper.UserService> ListUserService()
        {
            var mdc = new WebserviceDataContext();
            List<DataModelLib.Helper.UserService> listUserService= null;
            listUserService = (from userService in mdc.UserServices
                               join service in mdc.Services on userService.ServiceId equals service.ServiceId
                               join user in mdc.Users on userService.UserId equals user.UserId
                               orderby user.Username, service.ServiceName
                               select new DataModelLib.Helper.UserService()
                                   {
                                       Id = userService.Id,
                                       Username = user.Username,
                                       ServiceName = service.ServiceName,
                                       Status = userService.Status,
                                   }).ToList();
            
            return listUserService;
        }

        public static void AddUserService(UserService userService)
        {
            using (var hdc = new WebserviceDataContext())
            {
                hdc.UserServices.InsertOnSubmit(new DataModelLib.UserService
                {
                    ServiceId = userService.ServiceId,
                    UserId = userService.UserId,
                    UpdateUser = userService.UpdateUser,
                    UpdateDateTime = DateTime.Now,
                    Status = userService.Status
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

        public static void UpdateUserService(UserService userService)
        {
            using (var hdc = new WebserviceDataContext())
            {
                var getUserService = hdc.UserServices.Single(item => item.Id == userService.Id);

                    getUserService.ServiceId = userService.ServiceId;
                    getUserService.UserId = userService.UserId;
                    getUserService.UpdateUser = userService.UpdateUser;
                    getUserService.UpdateDateTime = DateTime.Now;
                    getUserService.Status = userService.Status;

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

        public static void DeleteUserService(int userServiceId)
        {
            using (var hdc = new WebserviceDataContext())
            {
                var userService = hdc.UserServices.Single(item => item.Id ==userServiceId);
                hdc.UserServices.DeleteOnSubmit(userService);
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
