using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using DataModelLib.Helper;


namespace DataModelLib.Page
{
    public static class MedalliaHelper
    {
        /// <summary>
        /// Connect TBDAT to retreive guest's data
        /// </summary>
        /// <param name="propertyCode"></param>
        /// <param name="checkOutDate"></param>
        public static List<Medallia> GetGuestByPropCode(string propertyCode, string checkOutDate)
        {
            var mdc = new MedalliaDataContext();
            List<Medallia> guest;
            if(checkOutDate.ToLower().Equals("any"))
            {
               guest = (from tbdat in mdc.TBDATs
                        where tbdat.PROPERTYCODE == propertyCode && tbdat.EMAIL != "&nbsp;" && tbdat.EMAIL != ""
                           orderby tbdat.PROPERTYCODE , tbdat.GUESTFIRSTNAME , tbdat.GUESTLASTNAME
                           select new Medallia()
                                        {
                                            Email = tbdat.EMAIL,
                                            GuestFirstName = tbdat.GUESTFIRSTNAME,
                                            GuestLastName = tbdat.GUESTLASTNAME,
                                            PropertyCode = tbdat.PROPERTYCODE,
                                            Country = tbdat.COUNTRY,
                                            RateCode = tbdat.RATECODE
                                        }).ToList();
            }
            else
            {
                var datetime = checkOutDate + " 00:00:00.000";
                var dt = Convert.ToDateTime(datetime);
                guest = (from tbdat in mdc.TBDATs
                         where tbdat.CHECKOUTDATE == dt && tbdat.PROPERTYCODE == propertyCode && tbdat.EMAIL != "&nbsp;" && tbdat.EMAIL != ""
                            orderby tbdat.PROPERTYCODE , tbdat.GUESTFIRSTNAME , tbdat.GUESTLASTNAME
                            select new Medallia()
                                        {
                                            Email = tbdat.EMAIL,
                                            GuestFirstName = tbdat.GUESTFIRSTNAME,
                                            GuestLastName = tbdat.GUESTLASTNAME,
                                            PropertyCode = tbdat.PROPERTYCODE,
                                            Country = tbdat.COUNTRY,
                                            RateCode = tbdat.RATECODE
                                        }).ToList();
            }

            return guest;
        }

        /// <summary>
        /// Connect TBDAT to retreive guest for all hotels
        /// </summary>
        /// <param name="checkOutDate"></param>
        public static List<Medallia> GetGuest(string checkOutDate)
        {
            var mdc = new MedalliaDataContext();
            List<Medallia> guest;
            if(checkOutDate.ToLower().Equals("any"))
            {
                guest = (from tbData in mdc.TBDATs
                         where tbData.EMAIL != "&nbsp;"&& tbData.EMAIL != ""
                         orderby tbData.PROPERTYCODE, tbData.GUESTFIRSTNAME, tbData.GUESTLASTNAME
                         select new Medallia()
                                        {
                                            Email = tbData.EMAIL,
                                            GuestFirstName = tbData.GUESTFIRSTNAME,
                                            GuestLastName = tbData.GUESTLASTNAME,
                                            PropertyCode = tbData.PROPERTYCODE,
                                            Country = tbData.COUNTRY,
                                            RateCode = tbData.RATECODE
                                        }).ToList();
            }
            else
            {
                var datetime = checkOutDate + " 00:00:00.000";
                var dt = Convert.ToDateTime(datetime);
                guest = (from tbData in mdc.TBDATs
                         where tbData.CHECKOUTDATE == dt && tbData.EMAIL != "&nbsp;" && tbData.EMAIL != ""
                         orderby tbData.PROPERTYCODE, tbData.GUESTFIRSTNAME, tbData.GUESTLASTNAME
                         select new Medallia()
                         {
                             Email = tbData.EMAIL,
                             GuestFirstName = tbData.GUESTFIRSTNAME,
                             GuestLastName = tbData.GUESTLASTNAME,
                             PropertyCode = tbData.PROPERTYCODE,
                             Country = tbData.COUNTRY,
                             RateCode = tbData.RATECODE
                         }).ToList();
            }
            return guest;
        }
    }
}
