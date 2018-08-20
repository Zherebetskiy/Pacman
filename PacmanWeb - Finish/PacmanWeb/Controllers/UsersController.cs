using Microsoft.AspNetCore.Mvc;
using PacmanWeb.BusinessLogic;
using PacmanWeb.Models;

namespace PacmanWeb.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userServise;

        public UsersController(IUserService userServise)
        {
            this.userServise = userServise;
        }
        
        // GET: Users
        public IActionResult Index()
        {
            return View(userServise.Get());
        }


        // GET: Users/Create/score
        public IActionResult Create(int score)
        {
            ViewBag.Score = score;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Score")] User user)
        {
            ViewBag.Score = user.Score;
            if (ModelState.IsValid)
            {
                userServise.Create(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
    }
}
