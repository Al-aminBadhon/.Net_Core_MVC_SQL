using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.DAL.Data;
using App.DAL.Models;
using System.Data;
using Microsoft.EntityFrameworkCore.Storage;
using App.BLL.Services;
using App.BLL.ServiceContracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using App.Home.FileUploadService;

namespace App.Home.Controllers
{
    public class GalleryController : Controller
    {
        private readonly MHDBContext _context;
        private readonly IGalleryService _galleryService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFileUploadService _fileUploadService;


        public GalleryController(IGalleryService galleryService, MHDBContext mHDBContext, IWebHostEnvironment webHostEnvironment, IFileUploadService fileUploadService)
        {
            this._galleryService = galleryService;
            this._context = mHDBContext;
            this._fileUploadService = fileUploadService;


        }

        // GET: Directors
        public async Task<IActionResult> Index()
        {
            List<TblGalleryPhoto> tblGalleryPhotos = await _galleryService.GetAllGallery();
            return View(tblGalleryPhotos);
        }

        // GET: Directors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Directors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("DirectorId,DirectorName,Designation,CompanyPost,Image,Details,FacebookLink,TwitterLink,LinkedInLink,IsDeleted,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy")]*/ TblGalleryPhoto tblGalleryPhoto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var imagePath = "";
                    if (tblGalleryPhoto.PhotoUpload != null)
                    {
                        imagePath = await _fileUploadService.UploadImageGallery(tblGalleryPhoto);
                        tblGalleryPhoto.Image = imagePath;
                    }
                    tblGalleryPhoto = await _galleryService.CreateGalleryPhoto(tblGalleryPhoto);

                    _context.Add(tblGalleryPhoto);
                    await _context.SaveChangesAsync();
                }
                catch
                {
                    throw;
                }
                //_directorsService.CreateDirectors(tblGalleryPhoto);
               
                return RedirectToAction(nameof(Index));
            }
            return View(tblGalleryPhoto);
        }

        // GET: Directors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblGalleryPhoto = await _context.TblDirectors.FindAsync(id);
            if (tblGalleryPhoto == null)
            {
                return NotFound();
            }
            return View(tblGalleryPhoto);
        }

        // POST: Directors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, /*[Bind("DirectorId,DirectorName,Designation,CompanyPost,Image,Details,FacebookLink,TwitterLink,LinkedInLink,IsDeleted,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy,PhotoUpload")]*/ TblGalleryPhoto tblGalleryPhoto)
        {
            if (id != tblGalleryPhoto.ImageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //using (IDbContextTransaction transaction = _context.Database.BeginTransaction()) {
                    //    transaction.Commit();
                    //    transaction.Rollback();
                    //}
                    var imagePath = "";
                    if (tblGalleryPhoto.PhotoUpload != null)
                    {
                        imagePath = await _fileUploadService.UploadImageGallery(tblGalleryPhoto);
                        tblGalleryPhoto.Image = imagePath;
                    }
                    tblGalleryPhoto = await _galleryService.UpdateGalleryPhoto(tblGalleryPhoto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblDirectorsExists(tblGalleryPhoto.ImageId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tblGalleryPhoto);
        }

        // GET: Directors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblGalleryPhoto = await _context.TblDirectors
                .FirstOrDefaultAsync(m => m.DirectorId == id);
            if (tblGalleryPhoto == null)
            {
                return NotFound();
            }

            return View(tblGalleryPhoto);
        }

        // POST: Directors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblGalleryPhoto = await _context.TblDirectors.FindAsync(id);
            _context.TblDirectors.Remove(tblGalleryPhoto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblDirectorsExists(int id)
        {
            return _context.TblDirectors.Any(e => e.DirectorId == id);
        }
    }
}
