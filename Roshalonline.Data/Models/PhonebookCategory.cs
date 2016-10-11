using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshalonline.Data.Models
{
    public class PhonebookCategory
    {
        public int PhonebookCategoryID { get; set; }
        public string PhonebookCategoryName { get; set; }

        public virtual ICollection<Phonebook> Phonbooks { get; set; }
        public PhonebookCategory()
        {
            Phonbooks = new List<Phonebook>();
        }
    }
}
