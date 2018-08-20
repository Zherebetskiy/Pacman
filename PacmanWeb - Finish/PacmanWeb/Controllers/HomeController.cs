using Microsoft.AspNetCore.Mvc;

namespace PacmanWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PlayGame()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Manual()
        {
            return View();
        }
    }
}
