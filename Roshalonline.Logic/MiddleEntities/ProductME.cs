using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roshalonline.Data.Models;

namespace Roshalonline.Logic.MiddleEntities
{
    public class ProductME
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Relevance Category { get; set; }
        public TypeProduct Type { get; set; }
        public string Description { get; set; }
        public IList<PathToImage> PathToPhotos { get; set; }
        public decimal Price { get; set; }
        public User Author { get; set; }
    }
}
