using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToysAndGamesUtil
{
    public interface ILocalStorage
    {
        Task StoreFile(IFormFile file, string key);

        List<string> ReadFiles(int? key);
    }
}
