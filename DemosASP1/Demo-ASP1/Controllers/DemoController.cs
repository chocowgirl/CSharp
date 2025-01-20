using Microsoft.AspNetCore.Mvc;

namespace Demo_ASP1.Controllers
{
    public class DemoController : Controller
    {

        [ViewData]
        public string Title { get; set; }
        public IActionResult Index()
        {
            //Here the view doesn't correspond to the name of the action
            //return View("IndexOld");
            Title = "Acceuil";
            return View();
        }

        [Route("Demo/Table/{nb}")]
        public IActionResult Table(int nb)
        {
            ViewData["table"] =nb; //contains the information of the variable table in Table.cshtml
            return View();
        }


    }
}
