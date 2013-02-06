using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace DataModelLib.Page
{
    public static class UserServiceHelper
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
                                       ServiceUrl = service.ServiceURL,
                                       Status = userService.Status,
                                       Ips = userService.Ips
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
                    Ips = userService.Ips,
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
                    getUserService.Ips = userService.Ips;

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

        public static bool AuthorizeUserService(string username, string password, string ip, string url, string service)
        {
            var isAuthorized = false;
            var userId = UserHelper.Authentication(username, password);
            var serviceId = ServiceHelper.GetServiceFromUrl(url,service);
            if (userId == 0 || serviceId == 0) return false;
            using (var wdc = new WebserviceDataContext())
            {
                var count = wdc.UserServices.Count(item => item.UserId==userId && item.ServiceId==serviceId && item.Status==1);
                if (count != 0)
                {
                    var ips = wdc.UserServices.Single(item => item.UserId == userId && item.ServiceId == serviceId && item.Status==1).Ips;
                    if(ip.Contains(';'))
                    {
                        var strIp = ips.Split(';');
                        foreach (var s in strIp)
                        {
                            if (s.Equals(ip)) isAuthorized = true;
                            break;
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(ips))
                        {
                            return true;
                        }
                        var cIp = ips.Remove(ips.Length - 1, 1);
                        if (cIp.Equals(ip)) isAuthorized = true;
                    }
                }
            }
            return isAuthorized;
        }
    }
}
