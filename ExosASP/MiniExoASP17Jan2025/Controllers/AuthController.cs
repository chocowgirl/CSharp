using Microsoft.AspNetCore.Mvc;

namespace MiniExoASP17Jan2025.Controllers
{
    public class AuthController : Controller
    {
        
        //public string ControllerPseudo { get; set; } = "Accès membres";

        [ViewData]
        public string Title { get; set; } = "Accès membres";

        [ViewData]
        public string message { get; set; }
        public string Subtitle { get; set; }
        public IActionResult Index()
        {
            return RedirectToAction("Register");
        }

        public IActionResult Login()
        {
            Subtitle = "- Se connecter";
            Title += Subtitle;
            return View();
        }

        public IActionResult Register()
        {
            //Subtitle = "- S'enregistrer";
            Title += "-S'enregistrer";

            if (TempData.ContainsKey("message"))
            {
                return RedirectToAction(nameof(Login));
            }
            else
            {
                TempData["message"] = "Vous etes maintenant enregistré!";
                return View();
            }
        }



    }
}
