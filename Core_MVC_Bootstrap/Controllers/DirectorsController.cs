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

namespace App.Home.Controllers
{
    public class DirectorsController : Controller
    {
        private readonly MHDBContext _context;

        public DirectorsController(MHDBContext context)
        {
            _context = context;
        }

        // GET: Directors
        public async Task<IActionResult> Index()
        {
           
            return View(await _context.TblDirectors.ToListAsync());
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
        public async Task<IActionResult> Edit(int id, [Bind("DirectorId,DirectorName,Designation,CompanyPost,Image,Details,FacebookLink,TwitterLink,LinkedInLink,IsDeleted,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy")] TblDirectors tblDirectors)
        {
            if (id != tblDirectors.DirectorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
