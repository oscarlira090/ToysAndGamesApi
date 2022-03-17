using StockManagementEntities.Models;
using StockManagementPersistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToysAndGamesUtil;

namespace ToysAndGamesBusiness
{
    public class ProductImages : IProductImages
    {
        private readonly ToysAndGamesDbContext _db;
        private readonly ILocalStorage _localSt;
        public ProductImages(ILocalStorage localSt, ToysAndGamesDbContext db)
        {
            _localSt = localSt;
            _db = db;
        }

        public List<string> GetImages(int ? productId)
        {
            try
            {
                if (productId == 0)
                    throw new Exception("Id Can't be null or 0");

                Product? product = _db.Products.FirstOrDefault(p => p.Id == productId);
                
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

