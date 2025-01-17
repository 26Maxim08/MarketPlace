using Microsoft.EntityFrameworkCore;
using MarketPlace.Models;

namespace MarketPlace.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<customer> customers { get; set; }
        public DbSet<product> products { get; set; }
        public DbSet<order> orders { get; set; }
        public DbSet<orderitem> orderitems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<orderitem>()
                .HasKey(oi => new { oi.orderid, oi.productid });

            modelBuilder.Entity<orderitem>()
                .HasOne(oi => oi.order)
                .WithMany(o => o.orderitems)
                .HasForeignKey(oi => oi.orderid);

            modelBuilder.Entity<orderitem>()
                .HasOne(oi => oi.product)
                .WithMany(p => p.orderitems)
                .HasForeignKey(oi => oi.productid);
        }
    }
}
