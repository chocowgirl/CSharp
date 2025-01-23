using Microsoft.AspNetCore.Mvc;
using MiniExoASP17Jan2025.Models;
using MiniExoASP17Jan2025.Models.Home;

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
            Address i3address = new Address()
            {
                Street = "Rue Gaucheret",
                Number = "88",
                ZipCode = 1030,
                City = "Bruxelles",
                Country = "Belgique"
            };
            PhoneNumber i3phone = new PhoneNumber()
            {
                Number = "02 219 15 10",
                International = "+32"
            };
            ContactViewModel model = new ContactViewModel()
            {
                Address = i3address,
                Phone = i3phone,
            };
            return View(model);
        }



    }
}
