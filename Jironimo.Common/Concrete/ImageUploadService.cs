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
    public class ImageUploadService: IImageUploadService
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
                string path = pathFolder + formFile.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await formFile.CopyToAsync(fileStream);
                   
                }
                return formFile.FileName;
            }
            return null;
        }
    }
}
