using App.Home.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace App.Home.Controllers
{
    public class Directors1Controller : Controller
    {
        private readonly MHDBContext _mHDBContext;
        public Directors1Controller(MHDBContext mHDBContext)
        {
            _mHDBContext = mHDBContext;
        }
        public async Task<IActionResult> Directors()
        {
            var demo = await _mHDBContext.TblDirectors.ToListAsync();
            return View(demo);
        }
        
        public IActionResult Create()
        {
            return View();
        }
    }
}
