﻿using System.Collections.Generic;
using DataModelLib.Page;
using WcfRestContrib.ServiceModel.Description;
using Webservice.Interfaces;
using Webservice.authentication;

namespace Webservice.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmailService" in code, svc and config file together.
    [WebAuthenticationConfiguration(typeof(WcfRestContrib.ServiceModel.Dispatcher.WebBasicAuthenticationHandler),typeof(CustomUserNameValidator), false,
"Webservice.authentication.CustomUserNameValidator")]
    public class EmailService : IEmailService
    {
        /// <summary>
        /// Retrieve a list of email address from guest who is currently checked out
        /// </summary>
        public List<string> GetEmails(string propertyCodes)
        {
            var emails = new List<string>();
            var propCode = propertyCodes.Split(',');
            if(propCode[0].ToLower().Equals("all"))
            {
                emails.AddRange(MedalliaHelper.GetEmails());
            }
            else
            {
                foreach (var t in propCode)
                {
                    emails.AddRange(MedalliaHelper.GetEmailByPropCode(t));
                }
            }
            
            return emails;
        }
    }
}