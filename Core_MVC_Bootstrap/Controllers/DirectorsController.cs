using App.Home.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace App.Home.Controllers
{
    public class DirectorsController : Controller
    {
        private readonly MHDBContext _mHDBContext;
        public DirectorsController(MHDBContext mHDBContext)
        {
            _mHDBContext = mHDBContext;
        }
        public async Task<IActionResult> Index()
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
