using Roshalonline.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Roshalonline.Web.Models
{
    public class UserVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public UserCategory UserRole { get; set; }
    }
}