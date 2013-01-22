using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModelLib.Helper
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string IP { get; set; }
        public int? Status { get; set; }
        public string StatusLabel { get; set; }
        public string DepartmentCode { get; set; }
        public string PropertyCode { get; set; }
        public DateTime UpdateDateTime { get; set; }
    }
}
