using Microsoft.AspNetCore.Mvc;

namespace MiniExoASP17Jan2025.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Register");
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }



    }
}
