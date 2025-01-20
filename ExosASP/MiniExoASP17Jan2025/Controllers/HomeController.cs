using Microsoft.AspNetCore.Mvc;

namespace MiniExoASP17Jan2025.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Contact()
        {
            return View();
        }



    }
}
