using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Roshalonline.Data.Models;

namespace Roshalonline.Data.Context
{
    class ModelsContext : DbContext
    {
        public DbSet<News> AllNews { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Phonebook> PhonebookNotes { get; set; }
        public DbSet<PresencePoint> PresencePoints { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Tarif> Tarifs { get; set; }
    }
}
