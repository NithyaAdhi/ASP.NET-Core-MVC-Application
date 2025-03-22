using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    public class WebAppContext: DbContext
    {
        public WebAppContext (DbContextOptions<WebAppContext> options) : base (options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //many to many
            modelBuilder.Entity<ItemClient>().HasKey
            (
                ic => new
                {
                    ic.ItemId,
                    ic.ClientId
                }
            );
            modelBuilder.Entity<ItemClient>().HasOne(i => i.Item).WithMany(ic => ic.ItemClients).HasForeignKey(i => i.ItemId);
            modelBuilder.Entity<ItemClient>().HasOne(c => c.Client).WithMany(ic => ic.ItemClients).HasForeignKey(c => c.ClientId);
            modelBuilder.Entity<Item>().HasData
            (
                new Item { Id = 4, Name= "micerophone",Price= 40, SerialNumberId=10 }
            );
            modelBuilder.Entity<SerialNumber>().HasData
           (
               new SerialNumber { Id = 10, Name = "mic456", ItemId = 4 }
           );
            modelBuilder.Entity<Category>().HasData
           (
               new Category { Id = 1, Name = "electronics" },
               new Category { Id = 2, Name = "books" }
           ) ;
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Item> Items { get; set; }

        public DbSet<SerialNumber> SerialNumbers { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<ItemClient> ItemClients { get; set; }
    }
}
