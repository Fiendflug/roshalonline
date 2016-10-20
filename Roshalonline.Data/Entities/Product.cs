﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshalonline.Data.Models
{
    public enum TypeProduct
    {
        Router,
        Modem,
        Other
    }
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Relevance Category { get; set; }
        public TypeProduct Type { get; set; }
        public string Description { get; set; }
        public IList<PathToImage> PathToPhotos { get; set; }
        public decimal Price { get; set; }

        public int AuthorID { get; set; }
        public User Author { get; set; }
    }
}
