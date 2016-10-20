using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Roshalonline.Data.Models
{    
    public class Note
    {     
        public int ID { get; set; }
        public string Header { get; set; }
        public Relevance Category { get; set; }
        public string PathToIcon { get; set; }
        public DateTime CreateDate { get; set; }
        public IList<PathToImage> PathToPhotos { get; set; }
        public string Body { get; set; }
        public long ViewsCount { get; set; }

        public int AuthorID { get; set; }
        public User Author { get; set; }
    }
}
