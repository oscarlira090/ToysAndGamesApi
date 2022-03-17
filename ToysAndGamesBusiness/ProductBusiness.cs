using StockManagementEntities.Models;
using StockManagementPersistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToysAndGamesBusiness
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly ToysAndGamesDbContext _db;

        public ProductBusiness(ToysAndGamesDbContext db)
        {
            _db = db;
        }
        public void CreateOrUpdate(Product product)
        {
            try
            {
                if (product.Id == 0)
                    _db.Products.Add(product);
                else
                    _db.Products.Update(product);

                _db.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Product> Get()
        {
            List<Product>? products = new List<Product>();
            try
            {
                return _db.Products.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Product GetById(int id)
        {
            Product? product = null;

            if (id == 0)
                throw new Exception("Id Can't be null or 0");

            try
            {
                product = _db.Products.FirstOrDefault(p => p.Id == id);
                if (product == null)
                {
                    throw new Exception("Product Not Found");
                }
                return product;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            Product? product = null;

            if (id == 0)
                throw new Exception("Id Can't be null or 0");

            try
            {
                product = _db.Products.FirstOrDefault(p => p.Id == id);
                if (product == null)
                    throw new Exception("Product Not Found");

                _db.Products.Remove(product);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
