using App.DAL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace App.Home.Controllers
{
    public class DashboardController : Controller
    {
        private readonly MHDBContext _dbContext;
        public DashboardController(MHDBContext dbContext)
        {
            this._dbContext = dbContext;
        }
        
        public IActionResult DashboardIndex()
        {
            ViewData["UserID"] = "Admin";
            ViewBag.TotalCompany = TotalCompany();
            return View();
        }


        public async Task<int> TotalCompany()
        {
            var total = await _dbContext.TblCompany.Where(x => x.IsActive == true).ToListAsync();
            
            return total.Count;
        }


    }

}
