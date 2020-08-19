using EF.DAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EF.DAL.Data
{
    public class SQliteDBContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        public DbSet<Item> items { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.DetachedLazyLoadingWarning));

            optionsBuilder.UseSqlite("Data Source=/Users/macbookpro/Desktop/SqliteDB/MyDataBase.DB");

            // optionsBuilder.UseSqlite("Filename =./ MyDataBase.DB");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>()
                .HasKey(e => new { e.OrderID, e.ItemID });
        }


    }
}
