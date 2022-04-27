using StockManagementEntities.Models;
using StockManagementPersistence;
using System.Linq;
using System.Linq.Expressions;
using ToysAndGamesServices.Contracts;
using ToysAndGamesUtil;

namespace ToysAndGamesBusiness.Services
{
    public class ProductService : IProductService
    {
        private readonly ToysAndGamesDbContext _db;
        private readonly ILocalStorage _localSt;

        public ProductService(ToysAndGamesDbContext db, ILocalStorage localSt)
        {
            _db = db;
            _localSt = localSt;
        }
        public Product UpSert(Product product)
        {
            try
            {
                //TODO: ERRROR if productId its 0 its my product not going to be added with the 0 ID ?
                //Comments: ID product is an identity column
                if (product.Id <= 0)
                    _db.Products.Add(product);
                else
                    _db.Products.Update(product);

                _db.SaveChanges();

                if (product.File != null) _localSt.StoreFile(product.File, product.Id.ToString());

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

            try
            {
                if (id <= 0) throw new Exception("Id Can't be null or 0");

                product = Get(p => p.Id == id).FirstOrDefault();

                if (product == null) throw new Exception("Product Not Found");
                
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

            try
            {
                if (id <= 0)throw new Exception("Id Can't be null or 0");

                product = Get(p => p.Id == id).FirstOrDefault();

                if (product == null) throw new Exception("Product Not Found");

                _db.Products.Remove(product);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Product> Get(Expression<Func<Product,bool>> predicate)
        {
            return _db.Products.Where(predicate).ToList();
        }
    }
}
