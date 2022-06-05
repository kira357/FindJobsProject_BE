using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
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
        
        public void DeleteFile(string fileName, IWebHostEnvironment _webHostEnvironment)
        {

                var imagePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", fileName);
                if (File.Exists(imagePath))
                    File.Delete(imagePath);
        }
        public async Task<string> SaveFileApply(IFormFile file, IWebHostEnvironment _webHostEnvironment)
        {
            string fileName = null;
            if (file != null)
            {
                fileName = new string(Path.GetFileNameWithoutExtension(file.FileName).Take(10).ToArray()).Replace(' ', '-');
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(file.FileName);

                var upload = Path.Combine(_webHostEnvironment.ContentRootPath, "Files");
                if (!Directory.Exists(upload))
                {
                    Directory.CreateDirectory(upload);
                }
                if (File.Exists(upload))
                {
                    File.Delete(upload);
                }

                if (file.Length > 0)
                {
                    var filePath = Path.Combine(upload, fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }

            return fileName;
        } 
        
      

    }
}
