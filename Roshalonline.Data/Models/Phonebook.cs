using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Roshalonline.Data.Models
{
    public class Phonebook
    {
        public int PhonebookID { get; set; }
        public int PhonebookPhonenumber { get; set; }
        public string PhonebookDescription { get; set; }

        public int CategoryID { get; set; }
        public virtual PhonebookCategory PhonebookCategory { get; set; }
    }
}
