using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshalonline.Data.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductPathToPhotos { get; set; }
        public decimal ProductPrice { get; set; }

        public int CategoryID { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
    }
}
