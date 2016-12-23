using Roshalonline.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshalonline.Data.Models
{
    public enum UserCategory
    {
        Administrator,
        Client
    }

    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public UserCategory UserRole { get; set; }

        public virtual IEnumerable<News> AllUserNews { get; set; }
        public virtual IEnumerable<Note> AllUserNotes { get; set; }
        public virtual IEnumerable<PeriodicTarif> AllUserInternetPeriodicTaris { get; set; }
        public virtual IEnumerable<TelephonyMgTarif> AllUserTelephonyMgTarifs { get; set; }
    }
}
