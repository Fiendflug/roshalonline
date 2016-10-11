using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshalonline.Data.Models
{
    public class ProductCategory
    {
        public int ProductCategoryID { get; set; }
        public string ProductCategoryName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public ProductCategory()
        {
            Products = new List<Product>();
        }
    }
}
