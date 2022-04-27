using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToysAndGamesServices.Contracts
{
    public interface IProductImagesService
    {
        List<string> GetImages(int? productId);

        string getBasePath();
    }
}
