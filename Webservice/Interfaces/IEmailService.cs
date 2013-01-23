
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using WcfRestContrib.ServiceModel.Description;
using WcfRestContrib.ServiceModel.Web;


namespace Webservice.Interfaces
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEmailService" in both code and config file together.
    [ServiceContract]
    [ServiceAuthentication]
    [ServiceConfiguration(true)]
    [ErrorHandler(typeof(WebErrorHandler))]
    public interface IEmailService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetEmails/{propertyCodes}")]
        List<string> GetEmails(string propertyCodes);
    }
}
