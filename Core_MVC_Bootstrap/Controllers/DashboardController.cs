using Microsoft.AspNetCore.Mvc;

namespace App.Home.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult DashboardIndex()
        {
            return View();
        }
    }
}
