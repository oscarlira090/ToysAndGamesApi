using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToysAndGamesBusiness
{
    public interface IProductImages
    {
        List<string> GetImages(int? productId);

        string getBasePath();
    }
}
