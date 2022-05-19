using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FindJobsProject.Helper
{
    public class MediaFile
    { 
        public async Task<string> SaveFile(IFormFile imageFile, IWebHostEnvironment _webHostEnvironment)
        {
            string fileName = null;
            if (imageFile != null)
            {
                fileName = new string(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
                var imagePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", fileName);
                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }
            }

            return fileName;
        }

    }
}
