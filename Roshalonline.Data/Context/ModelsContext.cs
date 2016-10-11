using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Roshalonline.Data.Models;

namespace Roshalonline.Data.Context
{
    public class ModelsContext : DbContext
    {
        public DbSet<News> AllNews { get; set; }
        public DbSet<NewsCategory> NewsCategories { get; set; }
        public DbSet<Note> Notes { get; set; }
        //public DbSet<Feedback> Feedbacks { get; set; }
        //public DbSet<Payment> Payments { get; set; }
        public DbSet<Phonebook> PhonebookNotes { get; set; }
        public DbSet<PhonebookCategory> PhonebookCategories { get; set; }
        //public DbSet<PresencePoint> PresencePoints { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Tarif> Tarifs { get; set; }
        public DbSet<TarifCategory> TarifCategories { get; set; }

        public ModelsContext() : base("ContextToRoshalDB")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<News>().HasRequired(n => n.NewsCategory)
                .WithMany(nc => nc.AllNewsInThisCategory)
                .HasForeignKey(n => n.CategoryID);
            modelBuilder.Entity<Tarif>().HasRequired(t => t.TarifCategory)
                .WithMany(tc => tc.Tarifs)
                .HasForeignKey(t => t.CategoryID);
            modelBuilder.Entity<Product>().HasRequired(p => p.ProductCategory)
                .WithMany(pc => pc.Products)
                .HasForeignKey(p => p.CategoryID);
            modelBuilder.Entity<Phonebook>().HasRequired(ph => ph.PhonebookCategory)
                .WithMany(phc => phc.Phonbooks)
                .HasForeignKey(ph => ph.CategoryID);
        }
    }
}
