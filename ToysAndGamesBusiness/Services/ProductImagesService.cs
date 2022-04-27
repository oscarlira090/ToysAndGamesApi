using StockManagementEntities.Models;
using StockManagementPersistence;
using ToysAndGamesServices.Contracts;
using ToysAndGamesUtil;

namespace ToysAndGamesBusiness
{
    public class ProductImagesService : IProductImagesService
    {
        private readonly ToysAndGamesDbContext _db;
        private readonly ILocalStorage _localSt;
        public ProductImagesService(ILocalStorage localSt, ToysAndGamesDbContext db)
        {
            _localSt = localSt;
            _db = db;
        }

        public string getBasePath()
        {
            return _localSt.getBasePath();
        }

        public List<string> GetImages(int ? productId)
        {
            try
            {
                //TODO: use HasValue instead of validating null or 0
                if (!productId.HasValue || productId <= 0 )
                    throw new Exception("Id Can't be null or <= 0");

                //TODO: IF the product ID is null this will throw an exception
                Product? product = _db.Products.FirstOrDefault(p => p.Id == productId);
                
                //This should be the first line not the last, validations are meant to be at the beggining
                if (product == null)
                    throw new Exception("Product Not Found");

                return _localSt.ReadFiles(product.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

