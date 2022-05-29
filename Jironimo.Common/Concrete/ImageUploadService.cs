using Jironimo.Common.Abstract.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jironimo.Common.Concrete
{
    public class ImageUploadService : IImageUploadService
    {
        private readonly IWebHostEnvironment _appEnvironment;

        public ImageUploadService(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        public async Task<string> UploadImage(IFormFile formFile,string pathFolder)
        {
            if (formFile != null)
            {
                var fileName = Guid.NewGuid()+ formFile.FileName;
                string path = pathFolder + fileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await formFile.CopyToAsync(fileStream);
                   
                }
                return fileName;
            }
            return null;
        }
        public bool DeleteImage(string fileName, string pathFolder)
        {
            string path = _appEnvironment.WebRootPath+pathFolder + fileName;
            if (!System.IO.File.Exists(path)) return false;
            try
            {
                System.IO.File.Delete(path);
                return true;
            }
            catch (Exception e)
            {
                //Debug.WriteLine(e.Message);
            }
            return false;
        }
    }
}
