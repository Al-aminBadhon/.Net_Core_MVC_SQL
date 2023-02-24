using App.BLL.ServiceContracts;
using App.DAL.Models;
using App.DAL.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.Services
{
    public class GalleryService : IGalleryService
    {
        private readonly IGalleryRepository _directorsRepository;
        public GalleryService(IGalleryRepository directorsRepository)
        {
            this._directorsRepository = directorsRepository;
        }

        public async Task<List<TblGalleryPhoto>> GetAllGallery()
        {
            return await _directorsRepository.GetAllGallery();
        }

        public async Task<TblGalleryPhoto> CreateGalleryPhoto(TblGalleryPhoto tblGallery)
        {
            return await _directorsRepository.CreateGalleryPhoto( tblGallery);
        }
        
        public async Task<TblGalleryPhoto> UpdateGalleryPhoto(TblGalleryPhoto tblGallery)
        {
            return await _directorsRepository.UpdateGalleryPhoto( tblGallery);
        }
    }
}
