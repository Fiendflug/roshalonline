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
        [Required]
        public int NoteID { get; set; }
        [Required, MaxLength(50)]
        public string NoteCategory { get; set; }
        [Required, MaxLength(50)]
        public string NoteHeader { get; set; }
        [MaxLength(300)]
        public string NotePathToIcon { get; set; }
        [Required]
        public DateTime NoteCreateDate { get; set; }
        [MaxLength(3000)]
        public string NotePathToPhotos { get; set; }
        [Required, MaxLength(3000)]
        public string NoteBody { get; set; }
        public long NoteViewsCount { get; set; }
    }
}
