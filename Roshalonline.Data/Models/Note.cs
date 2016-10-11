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
        public int NoteID { get; set; }
        public string NoteHeader { get; set; }
        public string NotePathToIcon { get; set; }
        public DateTime NoteCreateDate { get; set; }
        public string NotePathToPhotos { get; set; }
        public string NoteBody { get; set; }
        public long NoteViewsCount { get; set; }
    }
}
