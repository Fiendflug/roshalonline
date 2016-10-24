using Roshalonline.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshalonline.Logic.MiddleEntities
{
    public class FeedbackME
    {
        public int ID { get; set; }
        public Relevance Category { get; set; }
        public DateTime CreateDate { get; set; }
        public string Header { get; set; }
        public string ClientName { get; set; }
        public string ClientAddress { get; set; }
        public string ClientPhone { get; set; }
        public string Body { get; set; }
    }
}
