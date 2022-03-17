
using Microsoft.EntityFrameworkCore;
using StockManagementEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementPersistence
{
    public class ToysAndGamesDbContext : DbContext
    {
        public ToysAndGamesDbContext(DbContextOptions<ToysAndGamesDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Iron Man", Description = "Iron Man Mega Power", AgeRestriction = 4, Company = "Marvel", Price = 100 },
                new Product { Id = 2, Name = "BatMan", Description = "BatMan Luxury BatCar", AgeRestriction = 4, Company = "DC", Price = 100 },
                new Product { Id = 3, Name = "Kit Avengers", Description = "all caracters", AgeRestriction = 4, Company = "Marvel", Price = 500 }
                );
        }

        public DbSet<Product> Products { get; set; }
    }
}
