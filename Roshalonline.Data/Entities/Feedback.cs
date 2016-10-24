using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roshalonline.Data.Repositories;

namespace Roshalonline.Data.Models
{
    public class Feedback
    {
        public int ID { get; set; }
        public Relevance Category { get; set; }
        public DateTime CreateDate { get; set; }
        public string Header { get; set; }
        public string ClientName { get; set; }
        public string ClientAddress { get; set; }
        public string ClientPhone { get; set; }
        public string Body { get; set; }

        public static implicit operator Feedback(FeedbackRepository v)
        {
            throw new NotImplementedException();
        }
    }
}
