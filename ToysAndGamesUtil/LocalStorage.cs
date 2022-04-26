using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToysAndGamesEntities;

namespace ToysAndGamesUtil
{
    public class  LocalStorage : ILocalStorage
    {
        private readonly IHostingEnvironment _env;
        private readonly Settings _sett;

        private readonly string BasePath;
        public LocalStorage(IHostingEnvironment env, IOptions<Settings> sett)
        {
            _env = env;
            _sett = sett.Value;
            BasePath = $"{_env.WebRootPath}\\{_sett.ImageFolder}\\";
        }

        public string getBasePath()
        {
            return $"{_env.WebRootPath}\\";
        }

        

        public List<string> ReadFiles(int? key)
        {
            List<string> files = new List<string>();
            string[] filePaths;
            if (Directory.Exists($"{BasePath}product_{key}"))
                filePaths = Directory.GetFiles($"{BasePath}product_{key}");
            else
                throw new Exception("The product doesn't have any images");

            
            foreach (var item in filePaths)
                files.Add($"{_sett.ImageFolder}/product_{key}/{Path.GetFileName(item)}");
            
            return files;
        }

        public async Task StoreFile(IFormFile file, string key)
        {
            string folder = $"{BasePath}\\product_{key}";
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            using (var targetStream = new FileStream($"{folder}\\{Path.GetFileName(file.FileName)}", FileMode.Create))
            {
                await file.CopyToAsync(targetStream);
                targetStream.Close();
            }
        }
    }
}
