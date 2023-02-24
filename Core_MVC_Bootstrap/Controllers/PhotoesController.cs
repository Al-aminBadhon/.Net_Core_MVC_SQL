using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.DAL.Data;
using App.DAL.Models;

namespace App.Home.Controllers
{
    public class PhotoesController : Controller
    {
        private readonly MHDBContext _context;

        public PhotoesController(MHDBContext context)
        {
            _context = context;
        }

        // GET: Photoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblGalleryPhoto.ToListAsync());
        }

        // GET: Photoes/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var tblGalleryPhoto = await _context.TblGalleryPhoto
        //        .FirstOrDefaultAsync(m => m.ImageId == id);
        //    if (tblGalleryPhoto == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(tblGalleryPhoto);
        //}

        // GET: Photoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Photoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImageId,Name,Image,Flag,IsDelete,Details,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy")] TblGalleryPhoto tblGalleryPhoto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblGalleryPhoto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblGalleryPhoto);
        }

        // GET: Photoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

        // POST: Photoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImageId,Name,Image,Flag,IsDelete,Details,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy")] TblGalleryPhoto tblGalleryPhoto)
        {
            if (id != tblGalleryPhoto.ImageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblGalleryPhoto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblGalleryPhotoExists(tblGalleryPhoto.ImageId))
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

        // GET: Photoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblGalleryPhoto = await _context.TblGalleryPhoto
                .FirstOrDefaultAsync(m => m.ImageId == id);
            if (tblGalleryPhoto == null)
            {
                return NotFound();
            }

            return View(tblGalleryPhoto);
        }

        // POST: Photoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblGalleryPhoto = await _context.TblGalleryPhoto.FindAsync(id);
            _context.TblGalleryPhoto.Remove(tblGalleryPhoto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblGalleryPhotoExists(int id)
        {
            return _context.TblGalleryPhoto.Any(e => e.ImageId == id);
        }
    }
}
