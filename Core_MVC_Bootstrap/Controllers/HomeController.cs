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

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
