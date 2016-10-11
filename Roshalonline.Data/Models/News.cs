using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Roshalonline.Data.Models
{
    public class News
    {   
        public int NewsID { get; set; }
        public string NewsHeader { get; set; }
        public string NewsAuthor { get; set; } //Впоследствии заменить на атворизированного пользователя
        public string NewsPathToIcon { get; set; }
        public string NewsPathToPhotos { get; set; }
        public DateTime NewsCreateDate { get; set; }
        public string NewsBody { get; set; }        
        public long NewsViewsCount { get; set; }

        public int CategoryID { get; set; }
        public virtual NewsCategory NewsCategory { get; set; }
    }
}
