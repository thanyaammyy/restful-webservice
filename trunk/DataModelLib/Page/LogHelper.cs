using System;
using System.Data.SqlClient;
using System.Web;

namespace DataModelLib.Page
{
    public  static class LogHelper
    {
        public static void StoreError(string errMsg, string stacktrace, string Url)
        {
            try
            {
                using (var wdc = new WebserviceDataContext())
                {
                    wdc.ErrorLogs.InsertOnSubmit(new ErrorLog()
                    {
                        ErrorDate = DateTime.Now,
                        ClientIp = HttpContext.Current.Request.UserHostAddress,
                        Detail = stacktrace,
                        Message = errMsg,
                        Url = Url
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void StoreConsumenService(string Url)
        {
            try
            {
                using (var wdc = new WebserviceDataContext())
                {
                    wdc.ConsumeLogs.InsertOnSubmit(new ConsumeLog()
                    {
                        Date = DateTime.Now,
                        ClientIp = HttpContext.Current.Request.UserHostAddress,
                        Url = Url
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
