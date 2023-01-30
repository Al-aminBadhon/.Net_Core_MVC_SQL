using App.DAL.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;


namespace App.Home.FileUploadService
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileUploadService(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> UploadImageDirector(TblDirectors tblDirectors)
        {
            var locationWithName = "images/directors/";
            locationWithName += Guid.NewGuid().ToString() + "_" + tblDirectors.PhotoUpload.FileName;
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, locationWithName);
            await tblDirectors.PhotoUpload.CopyToAsync(new FileStream(filePath, FileMode.Create));
            var imagePath = "/" + locationWithName;

            return imagePath;
        }
    }
}
