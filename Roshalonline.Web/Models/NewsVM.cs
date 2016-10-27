using System;
using Roshalonline.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Roshalonline.Web.Models
{
    public class NewsVM
    {
        public int ID { get; set; }
        public string Header { get; set; }
        public User Author { get; set; }
        public Relevance Category { get; set; }
        public string PathToIcon { get; set; }
        public IList<PathToImage> PathToImages { get; set; }
        public DateTime CreateDate { get; set; }
        public string Body { get; set; }
        public long ViewsCount { get; set; }
    }
}