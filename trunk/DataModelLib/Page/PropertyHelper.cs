using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public static void AddProperty(Property property)
        {
            using (var hdc = new WebserviceDataContext())
            {
                hdc.Properties.InsertOnSubmit(new DataModelLib.Property
                {
                    PropertyCode = property.PropertyCode,
                    PropertyName = property.PropertyName,
                });

                try
                {
                    hdc.SubmitChanges();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2601 || ex.Number == 2627)
                    {
                        throw;
                    }
                }
            }
        }

        public static void UpdateProperty(Property property)
        {
            using (var hdc = new WebserviceDataContext())
            {
                var prop = hdc.Properties.Single(item => item.PropertyId == property.PropertyId);

                    prop.PropertyName = property.PropertyName;
                    prop.PropertyCode = property.PropertyCode;

                try
                {
                    hdc.SubmitChanges();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2601 || ex.Number == 2627)
                    {
                        throw;
                    }
                }
            }
        }

        public static void DeleteProperty(int propertyId)
        {
            using (var hdc = new WebserviceDataContext())
            {
                var property = hdc.Properties.Single(item => item.PropertyId == propertyId);
                hdc.Properties.DeleteOnSubmit(property);
                try
                {
                    hdc.SubmitChanges();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2601 || ex.Number == 2627)
                    {
                        throw;
                    }
                }
            }
        }
    }
}
