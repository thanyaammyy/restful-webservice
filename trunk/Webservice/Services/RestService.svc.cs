using System.Collections.Generic;
using Webservice.Interfaces;
using DataModelLib.Page;

namespace Webservice.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RestService" in code, svc and config file together.
    public class RestService : IRestService
    {
        public void DoWork()
        {
        }

        public string XmlData(string id)
        {
            return "You requested product id = " + id;
        }

        public string JsonData(string id)
        {
            return "You requested product id = " + id;
        }

   }
}
