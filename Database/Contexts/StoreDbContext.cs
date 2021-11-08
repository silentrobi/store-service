using Microsoft.EntityFrameworkCore;
using StoreService.Models;

namespace StoreService.Database.Contexts
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
        }

        //Tables
        public DbSet<Product> Product { get; set; }
        public DbSet<Market> Market { get; set; }
        public DbSet<Category> Category { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             base.OnModelCreating(modelBuilder);

            modelBuilder.HasPostgresExtension("uuid-ossp");

            // Product Table Configuration
            modelBuilder.Entity<Product>(
                p =>
                {
                    p.Property(x => x.Id).HasDefaultValueSql("uuid_generate_v4()");
                }
            );

            // Category Table Configuration
            modelBuilder.Entity<Category>(
                p =>
                {
                    p.Property(x => x.Id).HasDefaultValueSql("uuid_generate_v4()");
                }
            );
            
            // Market Table Configuration
            modelBuilder.Entity<Market>(
                p =>
                {
                    p.Property(x => x.Id).HasDefaultValueSql("uuid_generate_v4()");
                }
            );

            //MarketProduct Table Configuration (Many to many relation)
            modelBuilder.Entity<MarketProduct>().HasKey(mp => new { mp.MarketId, mp.ProductId });
            modelBuilder.Entity<MarketProduct>()
                .HasOne<Product>(mp => mp.Product)
                .WithMany(p => p.ProductMarkets)
                .HasForeignKey(mp => mp.ProductId);

            modelBuilder.Entity<MarketProduct>()
                .HasOne<Market>(mp => mp.Market)
                .WithMany(c => c.MarketProducts)
                .HasForeignKey(mp => mp.MarketId);
        }
    }
}