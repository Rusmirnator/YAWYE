using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using YAWYE.Core;

namespace YAWYE.Utilities
{
    public static class Utilities
    {

        public static string AddImageFromFile(Product Product, string webRootPath, IFormFile Image)
        {
            IFormFile image = Image;

            string uploadsFolder = Path.Combine(webRootPath, "Images");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using var fileStream = new FileStream(filePath, FileMode.Create);
            image.CopyTo(fileStream);
            Product.HasImage = true;

            return uniqueFileName;
        }

    }
}
