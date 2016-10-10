using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Roshalonline.Data.Models
{
    public class News
    {
        [Required]
        public int NewsID { get; set; }
        [Required, MaxLength(50)]
        public string NewsCategory { get; set; }
        [Required, StringLength(50)]
        public string NewsHeader { get; set; }
        [Required, StringLength(50)]
        public string NewsAuthor { get; set; }
        [StringLength(300)]
        public string NewsPathToIcon { get; set; }
        [StringLength(3000)]
        public string NotePathToPhotos { get; set; }
        [Required]
        public DateTime NewsCreateDate { get; set; }
        [Required, MaxLength(3000)]
        public string NewsBody { get; set; }        
        public long NewsViewsCount { get; set; }
    }
}
