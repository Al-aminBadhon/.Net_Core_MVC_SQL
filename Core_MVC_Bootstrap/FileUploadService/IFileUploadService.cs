using App.DAL.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace App.Home.FileUploadService
{
    public interface IFileUploadService
    { 
        Task<string> UploadImageDirector(TblDirectors tblDirectors);
    }
}
