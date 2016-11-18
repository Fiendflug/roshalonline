using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roshalonline.Data.Models;

namespace Roshalonline.Logic.MiddleEntities
{
    public class NoteME
    {
        public int ID { get; set; }
        public string Header { get; set; }
        public User Author { get; set; }
        public Relevance Category { get; set; }
        public string PathToIcon { get; set; }
        public DateTime CreateDate { get; set; }
        public string Body { get; set; }
        public long ViewsCount { get; set; }
    }
}
