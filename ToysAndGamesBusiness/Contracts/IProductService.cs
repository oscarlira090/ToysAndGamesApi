using StockManagementEntities.Models;
using System.Linq.Expressions;

namespace ToysAndGamesServices.Contracts
{
    public interface IProductService
    {
        List<Product> Get();


        //TODO: Use Generic repository with predicate instead of defining the GetBySomething
        List<Product> Get(Expression<Func<Product, bool>> predicate);
        Product GetById(int id);

        //TODO: CreateOrUpdate its also called UpSert
        Product UpSert(Product product);
        void Delete(int id);
    }
}