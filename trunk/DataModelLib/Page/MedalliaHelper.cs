using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DataModelLib.Page
{
    public static class MedalliaHelper
    {
        /// <summary>
        /// Connect TBDAT to retreive guest's email 
        /// </summary>
        /// <param name="propertyCode"></param>
        public static List<string> GetEmail(string propertyCode)
        {
            var mdc = new MedalliaDataContext();
            var mailList = mdc.TBDATs.Where(item => item.PROPERTYCODE == propertyCode
                && item.EMAIL != "&nbsp;" && item.EMAIL != ""
                && item.CHECKOUTDATE.Value.Date==DateTime.Now.Date.AddDays(-1)
                ).Select(item => item.EMAIL).ToList();
            return mailList;
        }
    }
}
