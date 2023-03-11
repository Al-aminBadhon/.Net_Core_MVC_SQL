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
    public class ExecutivesController : Controller
    {
        private readonly MHDBContext _context;

        public ExecutivesController(MHDBContext context)
        {
            _context = context;
        }

        // GET: Executives
        public async Task<IActionResult> ExecutiveIndex()
        {
            return View(await _context.TblExecutive.Where(x=> x.IsActive == true).ToListAsync());
        }

        // GET: Executives/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var tblExecutive = await _context.TblExecutive
        //        .FirstOrDefaultAsync(m => m.ExecutiveId == id);
        //    if (tblExecutive == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(tblExecutive);
        //}

        // GET: Executives/Create
        public IActionResult CreateExecutive()
        {
            return View();
        }

        // POST: Executives/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateExecutive(/*[Bind("ExecutiveId,UserRoleId,UserId,ExFirstName,ExLastName,Designation,Image,Address,Phone1,Phone2,Email,IsActive,IsApproved,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy")]*/ TblExecutive tblExecutive)
        {
            if (ModelState.IsValid)
            {
                
                tblExecutive.IsActive = true;
                tblExecutive.CreatedBy = 1;
                tblExecutive.CreatedDate = DateTime.Now;

                TblUser tblUser = new TblUser();
                tblUser.UserName = tblExecutive.Email;
                tblUser.UserPassword = "123456";
                _context.Add(tblUser);
                await _context.SaveChangesAsync();

                tblExecutive.UserId = tblUser.UserId;
                tblExecutive.UserRoleId = 3;
                _context.Add(tblExecutive);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ExecutiveIndex));
            }
            return View(tblExecutive);
        }

        // GET: Executives/Edit/5
        public async Task<IActionResult> EditExecutive(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblExecutive = await _context.TblExecutive.FindAsync(id);
            if (tblExecutive == null)
            {
                return NotFound();
            }
            return View(tblExecutive);
        }

        // POST: Executives/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditExecutive(int id, /*[Bind("ExecutiveId,UserRoleId,UserId,ExFirstName,ExLastName,Designation,Image,Address,Phone1,Phone2,Email,IsActive,IsApproved,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy")]*/ TblExecutive tblExecutive)
        {
            if (id != tblExecutive.ExecutiveId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    tblExecutive.UpdatedBy = 1;
                    tblExecutive.UpdatedDate = DateTime.Now;
                    _context.Update(tblExecutive);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblExecutiveExists(tblExecutive.ExecutiveId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ExecutiveIndex));
            }
            return View(tblExecutive);
        }

        //GET: Directors/Delete/5
        public async Task<IActionResult> DeleteExecutive(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblExecutive = await _context.TblExecutive
                .FirstOrDefaultAsync(m => m.ExecutiveId == id);
            if (tblExecutive == null)
            {
                return NotFound();
            }
            else
            {
                await DeleteExecutive(tblExecutive.ExecutiveId);
            }

            return RedirectToAction(nameof(ExecutiveIndex));
        }

        // POST: Directors/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteExecutive(int id)
        {
            //var tblGalleryPhoto = await _context.TblDirectors.FindAsync(id);
            //_context.TblDirectors.Remove(tblGalleryPhoto);
            //await _context.SaveChangesAsync();


            var tblExecutive = await _context.TblExecutive.FindAsync(id);
            tblExecutive.IsActive = false;
            _context.Update(tblExecutive);
            await _context.SaveChangesAsync();



            return View(tblExecutive);
        }


        private bool TblExecutiveExists(int id)
        {
            return _context.TblExecutive.Any(e => e.ExecutiveId == id);
        }
    }
}
