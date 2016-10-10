using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshalonline.Data.Models
{
    public class News
    {
        public int NewsID { get; set; }
        public string NewsHeader { get; set; }
        public string NewsAuthor { get; set; }
        public string NewsPathToIcon { get; set; }
        public DateTime NewsCreateDate { get; set; }
        public string NewsBody { get; set; }
        public long NewsViewsCount { get; set; }
    }
}
