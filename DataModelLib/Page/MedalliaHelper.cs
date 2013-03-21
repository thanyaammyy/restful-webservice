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
                        where tbdat.PROPERTYCODE == propertyCode && tbdat.EMAIL != "&nbsp;"
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
                var tick = Convert.ToInt64(checkOutDate);
                var coDate = new DateTime(tick);
                guest = (from tbdat in mdc.TBDATs
                         where tbdat.CHECKOUTDATE == coDate && tbdat.PROPERTYCODE == propertyCode && tbdat.EMAIL != "&nbsp;"
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
                         where tbData.EMAIL != "&nbsp;"
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
                var tick = Convert.ToInt64(checkOutDate);
                var coDate = new DateTime(tick);
                guest = (from tbData in mdc.TBDATs
                         where tbData.CHECKOUTDATE == coDate && tbData.EMAIL != "&nbsp;"
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
