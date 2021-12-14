using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkBridge.ShopBridge.DataAccess.Model;

namespace ThinkBridge.ShopBridge.DataAccess
{
    public class ShopBridgeDbContext : DbContext
    {
        public ShopBridgeDbContext()
        {

        }

        public ShopBridgeDbContext(DbContextOptions<ShopBridgeDbContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("data source=INR1802621\\SQL2016;initial catalog=ShopBridge2;persist security info=True;user id=sa;Password=P@ssw0rd;App=EntityFramework");

        public DbSet<Product> Product { get; set; }
        public DbSet<ProductOffer> ProductOffer { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //#region seed data
            //var product = new Product[] {
            //new Product { Id = 1, Name = "Avengers: Endgame", Description = "Movie 1", Price = 100 },
            //new Product { Id = 2, Name = "Avengers: Begining", Description = "Movie 2", Price = 181 }
            //};

            //var productOffer = new ProductOffer[] {
            //new ProductOffer { Id = 1 , fk_ProductId = 1, Name = "Avengers: Endgame", Description = "Movie 1",IsDelete = false, IsActive = true },
            //new ProductOffer { Id = 2 , fk_ProductId = 2, Name = "Avengers: Begining", Description = "Movie 2",IsDelete = false, IsActive = true }
            //};

            //modelBuilder.Entity<Product>().HasData(product);
            //modelBuilder.Entity<ProductOffer>().HasData(productOffer);

            //#endregion
           base.OnModelCreating(modelBuilder);
        }
    }
}
