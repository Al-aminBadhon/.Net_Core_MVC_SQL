using App.BLL.ServiceContracts;
using App.DAL.Data;
using App.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Core_MVC_Bootstrap.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDirectorsService _directorsService;
        private readonly MHDBContext _context;


        public HomeController(ILogger<HomeController> logger, IDirectorsService directorsService)
        {
            _logger = logger;
            this._directorsService = directorsService;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult CoreValues()
        {
            return View();
        }
        public IActionResult MissionVision()
        {
            return View();
        }
        
        public IActionResult AboutUs()
        {
            return View();
        }
        
        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult PrivacyStatement()
        {
            return View();
        }
        public IActionResult WhyBDCrew()
        {
            return View();
        }
        public IActionResult CrewManning()
        {
            return View();
        }
        public IActionResult PortAgency()
        {
            return View();
        }
        public IActionResult TechServices()
        {
            return View();
        }

        public IActionResult CrewTraining()
        {
            return View();
        }
        public async Task<IActionResult> BoardOfDirectors()
        {
            List<TblDirectors> listDirectors =  await _directorsService.GetAllDirectors();

            return View(listDirectors);
        }
        public  IActionResult ShipManagement()
        {
            return View();
        }

        public IActionResult Gallery()
        {
            List<TblGalleryPhoto> photos = new List<TblGalleryPhoto>();
            return View(photos);
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
