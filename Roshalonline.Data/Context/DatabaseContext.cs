using System.Data.Entity;
using Roshalonline.Data.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Roshalonline.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<News> AllNews { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Tarif> Tarifs { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<User> Users { get; set; }

        public DatabaseContext() : base("roshaldb")
        {
            //Database.SetInitializer(new Initializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
