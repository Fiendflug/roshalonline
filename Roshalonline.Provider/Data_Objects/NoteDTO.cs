using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshalonline.Provider.Data_Objects
{
    public class NoteDTO
    {
        public int NoteID { get; set; }
        public string NoteHeader { get; set; }
        public string NoteAuthor { get; set; }
        public string NotePathToIcon { get; set; }
        public DateTime NoteCreateDate { get; set; }
        public string NotePathToPhotos { get; set; }
        public string NoteBody { get; set; }
        public long NoteViewsCount { get; set; }
    }
}
