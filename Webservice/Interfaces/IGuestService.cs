using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Webservice.Interfaces
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGuest" in both code and config file together.
    [ServiceContract]
    public interface IGuestService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "GetGuestInfo/{propertyCodes}")]
        List<DataModelLib.TBDAT> GetGuestInfo(string propertyCodes);
    }
}
