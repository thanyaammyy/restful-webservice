﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfRestContrib.ServiceModel.Description;
using WcfRestContrib.ServiceModel.Web;
using DataModelLib.Helper;

namespace Webservice.Interfaces
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEcomService" in both code and config file together.
    [ServiceContract]
    [ServiceAuthentication]
    [ServiceConfiguration(true)]
    [ErrorHandler(typeof(WebErrorHandler))]
    public interface IEcomService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetGuest/{hotels}/{checkOutDate}")]
        Medallias GetGuest(string hotels, string checkOutDate);

        //[OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "Test/{hotels}/{date}")]
        //string Test(string hotels, string date);
    }
}
