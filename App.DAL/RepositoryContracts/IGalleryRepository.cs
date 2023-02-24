using App.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.RepositoryContracts
{
    public interface IGalleryRepository/*<TModel> where TModel : class*/
    {
        Task<List<TblGalleryPhoto>> GetAllGallery();
        Task<TblGalleryPhoto> CreateGalleryPhoto(TblGalleryPhoto tblDirectors);
        Task<TblGalleryPhoto> UpdateGalleryPhoto(TblGalleryPhoto tblDirectors);

    }
}
