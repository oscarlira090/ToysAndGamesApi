using StockManagementEntities.Models;
using System.Linq.Expressions;

namespace ToysAndGamesBusiness
{
    public interface IProductBusiness
    {
        List<Product> Get();


        //TODO: Use Generic repository with predicate instead of defining the GetBySomething
        //Task<IList<Product>> Get<Product>(Expression<Func<Product, bool>> predicate);
        Product GetById(int id);

        //TODO: CreateOrUpdate its also called UpSert
        Product CreateOrUpdate(Product product);
        void Delete(int id);
    }
}