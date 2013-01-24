using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModelLib.Helper
{
    public class UserService
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceUrl { get; set; }
        public int? Status { get; set; }
        public string Description { get; set; }
    }
}
