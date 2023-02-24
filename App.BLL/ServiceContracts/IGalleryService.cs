using App.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.ServiceContracts
{
    public interface IGalleryService
    {
        Task<List<TblGalleryPhoto>> GetAllGallery();
        Task<TblGalleryPhoto> CreateGalleryPhoto(TblGalleryPhoto tblDirectors);
        Task<TblGalleryPhoto> UpdateGalleryPhoto(TblGalleryPhoto tblDirectors);
    }
}
