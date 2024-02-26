using DataAccess.Entities;
using DataAccess.Seeder;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class ShopDBcontext : IdentityDbContext<User>
	{
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Basket> baskets { get; set; }
        public DbSet<ProductInBasket> productInBaskets { get; set; }
        public DbSet<Order> orders { get; set; }

        public ShopDBcontext(DbContextOptions options) : base(options) {  }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(SeedData.GetCategory());
            modelBuilder.Entity<Product>().HasData(SeedData.GetProduct());
        }
    }
}
