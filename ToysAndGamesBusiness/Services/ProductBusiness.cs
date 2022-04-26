using StockManagementEntities.Models;
using StockManagementPersistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToysAndGamesUtil;

namespace ToysAndGamesBusiness
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly ToysAndGamesDbContext _db;
        private readonly ILocalStorage _localSt;

        public ProductBusiness(ToysAndGamesDbContext db, ILocalStorage localSt)
        {
            _db = db;
            _localSt = localSt;
        }
        public Product CreateOrUpdate(Product product)
        {
            try
            {
                //TODO: ERRROR if productId its 0 its my product not going to be added with the 0 ID ?
                if (!product.Id.HasValue)
                    _db.Products.Add(product);
                else
                    _db.Products.Update(product);

                _db.SaveChanges();

                if (product.File != null)
                    _localSt.StoreFile(product.File, product.Id.ToString());

                return product;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Product> Get()
        {
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

        //public async Task<IList<Product>> Get(Expression<Func<Product, bool>> predicate, Expression<Func<Product)
        //{
        //    return _db.Products.Where(predicate).ToList();
        //}

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
                _db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
