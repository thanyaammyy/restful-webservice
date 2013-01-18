using System.Collections.Generic;
using DataModelLib.Page;
using Webservice.Interfaces;

namespace Webservice.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmailService" in code, svc and config file together.
    public class EmailService : IEmailService
    {
        /// <summary>
        /// Retrieve a list of email address from guest who is currently checked out
        /// </summary>
        public List<string> GetEmails(string propertyCodes)
        {
            var emails = new List<string>();
            var propCode = propertyCodes.Split(',');
            foreach (var t in propCode)
            {
                emails.AddRange(MedalliaHelper.GetEmail(t));
            }
            return emails;
        }
    }
}
