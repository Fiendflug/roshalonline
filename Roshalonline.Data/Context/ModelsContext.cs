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

            modelBuilder.Entity<News>().Property(n => n.NewsHeader).HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<News>().Property(n => n.NewsAuthor).IsRequired();
            modelBuilder.Entity<News>().Property(n => n.NewsPathToIcon).HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<News>().Property(n => n.NewsPathToPhotos).HasMaxLength(100);
            modelBuilder.Entity<News>().Property(n => n.NewsCreateDate).IsRequired();
            modelBuilder.Entity<News>().Property(n => n.NewsBody).HasMaxLength(3000)
                .IsRequired();
            modelBuilder.Entity<News>().Property(n => n.NewsViewsCount).IsRequired();

            modelBuilder.Entity<Note>().Property(note => note.NoteHeader).HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Note>().Property(note => note.NoteAuthor).IsRequired();
            modelBuilder.Entity<Note>().Property(note => note.NotePathToIcon).HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<Note>().Property(note => note.NotePathToPhotos).HasMaxLength(100);
            modelBuilder.Entity<Note>().Property(note => note.NoteCreateDate).IsRequired();
            modelBuilder.Entity<Note>().Property(note => note.NoteBody).HasMaxLength(3000)
                .IsRequired();
            modelBuilder.Entity<Note>().Property(note => note.NoteViewsCount).IsRequired();

            modelBuilder.Entity<Tarif>().Property(t => t.TarifName).HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<Tarif>().Property(t => t.TarifDescription).HasMaxLength(1000)
                .IsRequired();
            modelBuilder.Entity<Tarif>().Property(t => t.TarifPrice).IsRequired();

            modelBuilder.Entity<Product>().Property(p => p.ProductName).HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.ProductDescription).HasMaxLength(1000)
                .IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.ProductPathToPhotos).HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.ProductPrice).IsRequired();

            modelBuilder.Entity<Phonebook>().Property(phoneb => phoneb.PhonebookPhonenumber).IsRequired();
            modelBuilder.Entity<Phonebook>().Property(phoneb => phoneb.PhonebookDescription).HasMaxLength(1000)
                .IsRequired();

            modelBuilder.Entity<NewsCategory>().Property(nc => nc.NewsCategoryName).HasMaxLength(30)
                .IsRequired();

            modelBuilder.Entity<TarifCategory>().Property(tc => tc.TarifCategoryName).HasMaxLength(30)
                .IsRequired();

            modelBuilder.Entity<PhonebookCategory>().Property(phonebc => phonebc.PhonebookCategoryName).HasMaxLength(30)
                .IsRequired();

            modelBuilder.Entity<ProductCategory>().Property(pc => pc.ProductCategoryName).HasMaxLength(30)
                .IsRequired();
        }
    }
}
