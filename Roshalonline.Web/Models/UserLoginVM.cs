using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Roshalonline.Data.Models;

namespace Roshalonline.Web.Models
{
    public class UserLoginVM
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public UserCategory UserRole { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}