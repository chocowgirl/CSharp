using Microsoft.AspNetCore.Mvc;

namespace MiniExoASP17Jan2025.Controllers
{
    public class HomeController : Controller
    {
        public string ControllerPseudo { get; set; } = "Interface 3";

        [ViewData]  //Note: for EACH THING that you'll use in ViewData, you have to put this [ViewData] Headline
        public string Title { get; set; }
        public string Subtitle { get; set; }

        public IActionResult Index()
        {
            Subtitle = "- Acceuil";
            Title = ControllerPseudo + Subtitle;
            return View();
        }


        public IActionResult Contact()
        {
            Subtitle = "- Nous contacter";
            Title = ControllerPseudo + Subtitle;
            return View();
        }



    }
}
