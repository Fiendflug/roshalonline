using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshalonline.Data.Models
{
    public class NewsCategory
    {
        public int NewsCategoryID { get; set; }
        public string NewsCategoryName { get; set; }
                
        public virtual ICollection<News> AllNewsInThisCategory { get; set; }
        public NewsCategory()
        {
            AllNewsInThisCategory = new List<News>();
        }
    }
}
