using StockManagementEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToysAndGamesTesting
{
    public class SampleData
    {
        public const string ProductNotFoundMessage = "Product Not Found";
        public const string ProductDeleteMessage = "The product has been deleted succesfully";
        public static List<Product> GetSampleProducts()
        {
            return new List<Product> {
                new Product { Id = 1, Name = "Spiderman", Description = "", AgeRestriction = 5, Company = "Marvel", Price = 200 },
                new Product { Id = 2, Name = "Thor", Description = "", AgeRestriction = 5, Company = "Marvel", Price = 150 },
                new Product { Id = 3, Name = "Hulk", Description = "", AgeRestriction = 5, Company = "Marvel", Price = 500 },
                new Product { Id = 4, Name = "Superman", Description = "", AgeRestriction = 5, Company = "DC", Price = 1000 }
            };
        }

        public static Product GetSampleProduct()
        {
            return new Product { Id = 1, Name = "Spiderman", Description = "", AgeRestriction = 5, Company = "Marvel", Price = 200 };
        }
    }
}
