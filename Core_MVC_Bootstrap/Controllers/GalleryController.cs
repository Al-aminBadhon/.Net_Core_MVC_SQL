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
        public async Task<IActionResult> GalleryPhotoIndex()
        {
            List<TblGalleryPhoto> tblGalleryPhotos = await _galleryService.GetAllGallery();



            return View(tblGalleryPhotos);
        }
        public async Task<IActionResult> GetGalleryPhoto()
        {
            List<TblGalleryPhoto> tblGalleryPhotos = await _galleryService.GetAllGallery();



            return new JsonResult(tblGalleryPhotos);
        }

        // GET: Directors/Create
        public IActionResult CreateGalleryPhoto()
        {
            //List<SelectListItem> category = new List<SelectListItem>()
            //{
            //    new SelectListItem { Value = "1", Text = "Certificate" },
            //    new SelectListItem { Value = "2", Text = "Random" },
            //    new SelectListItem { Value = "3", Text = "Visit" },

            //};
            List<string> category = new List<string>()
            { "Certificate" ,"Random" ,"Visit"

            };

            //assigning SelectListItem to view Bag
            ViewBag.Category = category;

            return View();
        }

        // POST: Directors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateGalleryPhoto(/*[Bind("ImageId,Name,Image,Flag,IsDelete,Details,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy")]*/ TblGalleryPhoto tblGalleryPhoto)
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
                    //tblGalleryPhoto = await _galleryService.CreateGalleryPhoto(tblGalleryPhoto);
                    List<string> category = new List<string>()
            { "Certificate" ,"Random" ,"Visit"

            };

                    //assigning SelectListItem to view Bag
                    ViewBag.Category = category;

                    //CommonService.SetCommonFields(tblGalleryPhoto);
                    tblGalleryPhoto.IsDelete = false;
                    tblGalleryPhoto.CreatedBy = 1;
                    tblGalleryPhoto.CreatedDate = DateTime.Now;


                    _context.Add(tblGalleryPhoto);
                    await _context.SaveChangesAsync();
                }
                catch
                {
                    throw;
                }
                //_directorsService.CreateDirectors(tblGalleryPhoto);

                return RedirectToAction(nameof(GalleryPhotoIndex));
            }
            return View(tblGalleryPhoto);
        }

        // GET: Directors/Edit/5
        public async Task<IActionResult> EditGalleryPhoto(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblGalleryPhoto = await _context.TblGalleryPhoto.FindAsync(id);
            if (tblGalleryPhoto == null)
            {
                return NotFound();
            }
            return View(tblGalleryPhoto);
        }

        // POST: Directors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditGalleryPhoto(int id, /*[Bind("ImageId,Name,Image,Flag,IsDelete,Details,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy")]*/ TblGalleryPhoto tblGalleryPhoto)
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
                return RedirectToAction(nameof(GalleryPhotoIndex));
            }
            return View(tblGalleryPhoto);
        }

        // GET: Directors/Delete/5
        public async Task<IActionResult> GalleryphotoDelete(int? id)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GalleryphotoDelete(int id) 
        {
            var tblGalleryPhoto = await _context.TblDirectors.FindAsync(id);
            _context.TblDirectors.Remove(tblGalleryPhoto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(GalleryPhotoIndex));
        }

        private bool TblDirectorsExists(int id)
        {
            return _context.TblDirectors.Any(e => e.DirectorId == id);
        }
    }
}
