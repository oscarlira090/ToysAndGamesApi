using StockManagementEntities.Models;

namespace ToysAndGamesBusiness
{
    public interface IProductBusiness
    {
        List<Product> Get();
        Product GetById(int id);
        Product CreateOrUpdate(Product product);
        void Delete(int id);

    }
}