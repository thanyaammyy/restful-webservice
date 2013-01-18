using System;
using System.Collections.Generic;
using System.Linq;
using DataModelLib;

namespace DataModelLib.Page
{
    public static class PropertyHelper
    {
        public static List<Property> ListProperty()
        {
            var wdc = new WebserviceDataContext();
            return wdc.Properties.ToList();
        }
    }
}
