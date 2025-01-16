using System.Diagnostics;
using Demo_ASP1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo_ASP1.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        ////below shows how to create an action that needs an id to execute
        ////The URL in this case will be Home/DemoParams/#provided (if no # provided 0 shows b/c it's default)
        //public string DemoParams(int id)
        //{
        //    return $"mon chiffre port-bonheur est le : {id}";
        //}

        //The attribute (in this case Route) should always find itself above the method for which it applies
        [Route("Home/Addition/{nb1}/{nb2}")]
        [Route("Home/{nb1}/plus/{nb2}")]
        public int Addition(int nb1, int nb2)
        {
            return nb1 + nb2;
        }
        //The URL to access the above will be: Home/Addition

        [Route("Math/Multiple/{nb1}")]
        public string Multiple(int nb1)
        { 
            string disp = "";
            //string temp = "";
            for (int i = 1; i < 11; i++)
            {
                string temp = ($"{i} times {nb1} = {i * nb1} \n");
                disp += temp;
            }
            return disp;
        }

        [Route("Home/Aide")]
        public string Aide()
        {
            string message = "To go back to the welcome page go to http://www.localhost:5076/";
            return message;
        }


        //[Route("Home/Message/{text}")]
        public string Message(string text= "Aucun text actuellement")
        {
            return text;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
