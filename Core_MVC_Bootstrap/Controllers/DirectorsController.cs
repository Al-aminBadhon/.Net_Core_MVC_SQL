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

namespace App.Home.Controllers
{
    public class DirectorsController : Controller
    {
        private readonly MHDBContext _context;
        private readonly IDirectorsService _directorsService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DirectorsController(IDirectorsService directorsService, MHDBContext mHDBContext, IWebHostEnvironment webHostEnvironment)
        {
            this._directorsService = directorsService;
            this._context = mHDBContext;
            this._webHostEnvironment = webHostEnvironment;

        }

        // GET: Directors
        public async Task<IActionResult> Index()
        {
            List<TblDirectors> listDirectors = await _directorsService.GetAllDirectors();
            return View(listDirectors);
        }

        // GET: Directors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblDirectors = await _context.TblDirectors
                .FirstOrDefaultAsync(m => m.DirectorId == id);

            if (tblDirectors == null)
            {
                return NotFound();
            }

            return View(tblDirectors);
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
        public async Task<IActionResult> Create([Bind("DirectorId,DirectorName,Designation,CompanyPost,Image,Details,FacebookLink,TwitterLink,LinkedInLink,IsDeleted,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy")] TblDirectors tblDirectors)
        {
            if (ModelState.IsValid)
            {
                //_directorsService.CreateDirectors(tblDirectors);
                if (tblDirectors.PhotoUpload != null)
                {
                    var locationWithName = "images/directors";
                    locationWithName += Guid.NewGuid().ToString() + "_" + tblDirectors.PhotoUpload.FileName;
                    var filePath = Path.Combine(_webHostEnvironment.WebRootPath, locationWithName);
                    await tblDirectors.PhotoUpload.CopyToAsync(new FileStream(filePath, FileMode.Create));
                }
                _context.Add(tblDirectors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblDirectors);
        }

        // GET: Directors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblDirectors = await _context.TblDirectors.FindAsync(id);
            if (tblDirectors == null)
            {
                return NotFound();
            }
            return View(tblDirectors);
        }

        // POST: Directors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, /*[Bind("DirectorId,DirectorName,Designation,CompanyPost,Image,Details,FacebookLink,TwitterLink,LinkedInLink,IsDeleted,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy,PhotoUpload")]*/ TblDirectors tblDirectors)
        {
            if (id != tblDirectors.DirectorId)
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
                    if (tblDirectors.PhotoUpload != null)
                    {
                        var locationWithName = "images/directors/";
                        locationWithName += Guid.NewGuid().ToString() + "_" + tblDirectors.PhotoUpload.FileName;
                        var filePath = Path.Combine(_webHostEnvironment.WebRootPath, locationWithName);
                        await tblDirectors.PhotoUpload.CopyToAsync(new FileStream(filePath, FileMode.Create));
                        imagePath = "/"+ locationWithName;
                    }

                    tblDirectors.Image = imagePath;

                    _context.Update(tblDirectors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblDirectorsExists(tblDirectors.DirectorId))
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
            return View(tblDirectors);
        }

        // GET: Directors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblDirectors = await _context.TblDirectors
                .FirstOrDefaultAsync(m => m.DirectorId == id);
            if (tblDirectors == null)
            {
                return NotFound();
            }

            return View(tblDirectors);
        }

        // POST: Directors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblDirectors = await _context.TblDirectors.FindAsync(id);
            _context.TblDirectors.Remove(tblDirectors);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblDirectorsExists(int id)
        {
            return _context.TblDirectors.Any(e => e.DirectorId == id);
        }
    }
}
