using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataModelLib.Page
{
    public static class ServiceHelper
    {
        public static List<Service> ListService()
        {
            var wdc = new WebserviceDataContext();
            return wdc.Services.ToList();
        }

        public static void AddService(Service service)
        {
            using (var wdc = new WebserviceDataContext())
            {
                wdc.Services.InsertOnSubmit(new DataModelLib.Service
                {
                    ServiceURL = service.ServiceURL,
                    ServiceName = service.ServiceName,
                    UpdateUser = service.UpdateUser,
                    UpdateDateTime = DateTime.Now,
                    Description = service.Description
                });

                try
                {
                    wdc.SubmitChanges();
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

        public static void UpdateService(Service service)
        {
            using (var wdc = new WebserviceDataContext())
            {
                var s = wdc.Services.Single(item => item.ServiceId == service.ServiceId);

                s.ServiceName = service.ServiceName;
                s.ServiceURL = service.ServiceURL;
                s.UpdateUser = service.UpdateUser;
                s.UpdateDateTime = DateTime.Now;
                s.Description = service.Description;

                try
                {
                    wdc.SubmitChanges();
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

        public static void DeleteService(int serviceId)
        {
            using (var wdc = new WebserviceDataContext())
            {
                var service = wdc.Services.Single(item => item.ServiceId == serviceId);
                wdc.Services.DeleteOnSubmit(service);
                try
                {
                    wdc.SubmitChanges();
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

        public static int GetServiceFromUrl(string url, string service)
        {
            var serviceId = 0;

            using (var hdc = new WebserviceDataContext())
            {
                var count = hdc.Services.Count(item => item.ServiceURL.ToLower().Equals(url.ToLower())&&item.ServiceName.ToLower().Equals(service.ToLower()));
                if (count != 0)
                {
                    var services = hdc.Services.Single(item => item.ServiceURL.Equals(url));
                    serviceId = services.ServiceId;
                }
            }
            return serviceId;
        }
    }
}
