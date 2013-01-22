using System.Collections.Generic;
using DataModelLib.Page;
using Webservice.Interfaces;

namespace Webservice.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Guest" in code, svc and config file together.
    public class GuestService : IGuestService
    {
        public List<DataModelLib.TBDAT> GetGuestInfo(string propertyCodes)
        {
            var data = new List<DataModelLib.TBDAT>();
            var propCode = propertyCodes.Split(',');
            if (propCode[0].ToLower().Equals("all"))
            {
                data.AddRange(MedalliaHelper.GetGuest());
            }
            else
            {
                foreach (var t in propCode)
                {
                    data.AddRange(MedalliaHelper.GetGuestByPropCode(t));
                }
            }

            return data;
        }
    }
}
