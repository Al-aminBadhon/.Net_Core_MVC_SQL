using App.DAL.Data;
using App.DAL.Models;
using App.DAL.RepositoryContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore;

namespace App.DAL.Repositories
{
    public class GalleryRepository/*<TModel>*/ : IGalleryRepository/*<TModel> where TModel : class*/
    {
        private readonly MHDBContext _mHDBContext;


        public GalleryRepository(MHDBContext mHDBContext)
        {
            _mHDBContext = mHDBContext;

        }

        public async Task<List<TblGalleryPhoto>> GetAllGallery()
        {
            try
            {
                List<TblGalleryPhoto> directors = new List<TblGalleryPhoto>();
                //directors = _mHDBContext.TblGalleryPhoto.FromSql("select a.* from tblGallery a  where a.IsDeleted = 0").ToList();
                directors = await _mHDBContext.TblGalleryPhoto.Where(x => x.IsDelete == false).ToListAsync();

                //const String sql = "select a.* from tblGallery a  where a.IsDeleted = 0";
                //directors = _mHDBContext.Database.ExecuteSqlCommand(sql);
                return directors;
            }
            catch
            {
                throw;
            }

        }
        public async Task<TblGalleryPhoto> CreateGalleryPhoto(TblGalleryPhoto model)
        {
            try
            {

                return model;
            }
            catch
            {
                throw;
            }

        }
        public async Task<TblGalleryPhoto> UpdateGalleryPhoto(TblGalleryPhoto tblGallery)
        {
            try
            {


                tblGallery.UpdatedBy = 1;
                tblGallery.UpdatedDate = DateTime.Now;
                _mHDBContext.Update(tblGallery);
                await _mHDBContext.SaveChangesAsync();

            }
            catch
            {
                throw;
            }
            return tblGallery;
        }

    }
}
