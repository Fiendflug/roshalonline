using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshalonline.Provider.Data_Objects
{
    public class NewsDTO
    {
        public int NewsID { get; set; }
        public string NewsHeader { get; set; }
        public string NewsAuthor { get; set; } //Впоследствии заменить на атворизированного пользователя
        public string NewsPathToIcon { get; set; }
        public string NewsPathToPhotos { get; set; }
        public DateTime NewsCreateDate { get; set; }
        public string NewsBody { get; set; }
        public NewsCategoryDTO NewsCategory { get; set; }
        public long NewsViewsCount { get; set; }
    }
}
