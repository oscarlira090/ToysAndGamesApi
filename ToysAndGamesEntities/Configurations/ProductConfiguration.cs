using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManagementEntities.Models;


namespace ToysAndGamesEntities.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(50);

            builder.Property(x => x.Description).HasMaxLength(100);

            builder.Property(x => x.Company).IsRequired();
            builder.Property(x => x.Company).HasMaxLength(100);

            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Price).HasPrecision(6, 2);

            builder.HasData(Get());


        }
        private List<Product> Get()
        {
            return new List<Product>()
                {
                    new Product { Id = 1, Name = "Iron Man", Description = "Iron Man Mega Power", AgeRestriction = 4, Company = "Marvel", Price = 100 },
                    new Product { Id = 2, Name = "BatMan", Description = "BatMan Luxury BatCar", AgeRestriction = 4, Company = "DC", Price = 100 },
                    new Product { Id = 3, Name = "Kit Avengers", Description = "all caracters", AgeRestriction = 4, Company = "Marvel", Price = 500 }
                };
        }
    }
}
