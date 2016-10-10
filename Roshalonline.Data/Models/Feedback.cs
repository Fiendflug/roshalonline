using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshalonline.Data.Models
{
    public class Feedback
    {
        public int FeedbackID { get; set; }
        public string FeedbackCategory { get; set; }
        public DateTime FeedbackCreateDate { get; set; }
        public string FeedbackHeader { get; set; }
        public string FeedbackAuthorName { get; set; }
        public string FeedbackAuthorAddress { get; set; }
        public string FeedbackAuthorPhoneNumber { get; set; }
        public string FeedbackBody { get; set; }
    }
}
