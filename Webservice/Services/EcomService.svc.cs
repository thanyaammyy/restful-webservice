using System;
using System.Collections.Generic;
using DataModelLib.Helper;
using DataModelLib.Page;
using WcfRestContrib.ServiceModel.Description;
using Webservice.Interfaces;
using Webservice.authentication;

namespace Webservice.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EcomService" in code, svc and config file together.
    [WebAuthenticationConfiguration(typeof(WcfRestContrib.ServiceModel.Dispatcher.WebBasicAuthenticationHandler), 
        typeof(CustomUserNameValidator), 
        true,
        "Webservice.authentication.CustomUserNameValidator")]
    public class EcomService : IEcomService
    {
        /// <summary>
        /// Retrieve a list of email address from guest who is currently checked out
        /// </summary>
        public List<DataModelLib.Helper.Medallia> GetGuest(string hotels, string checkOutDate)
        {
            var guest = new List<Medallia>();
            if (string.IsNullOrEmpty(hotels) || string.IsNullOrEmpty(checkOutDate)) return guest;
            var propCode = hotels.Split(',');
            if (propCode[0].ToLower().Equals("all"))
            {
                guest.AddRange(MedalliaHelper.GetGuest(checkOutDate));
            }
            else
            {
                foreach (var t in propCode)
                {
                    guest.AddRange(MedalliaHelper.GetGuestByPropCode(t, checkOutDate));
                }
            }

            return guest;
        }
    }
}
