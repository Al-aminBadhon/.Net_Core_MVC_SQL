using App.DAL.Data;
using App.DAL.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace App.Home.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        
        private readonly MHDBContext _dbContext;
        private readonly AppUser _appUser;
        public DashboardController(MHDBContext dbContext, AppUser appUser)
        {
            this._dbContext = dbContext;
            this._appUser = appUser;
        }
        
        public IActionResult DashboardIndex()
        {
            if (!string.IsNullOrEmpty(_appUser.UserFirstName)) 
            {
                ViewData["UserFirstName"] = _appUser.UserFirstName;
            }
           
                ViewData["UserRoleID"] = _appUser.UserRoleID;
            
            
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
