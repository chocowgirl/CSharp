using Demo_ASP1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo_ASP1.Controllers
{
    public class DemoController : Controller
    {

        [ViewData]
        public string Title { get; set; }

        private static Dictionary<int, PersonneDetails> _users = new Dictionary<int, PersonneDetails>() 
        {
            {1, new PersonneDetails() {LastName = "Willis", FirstName = "Bruce", BirthDate = new DateOnly(1954,5,13)} },
            {2, new PersonneDetails() {LastName = "Bassinger", FirstName = "Kim", BirthDate = new DateOnly(1966,6,6)} }
        };

        private static List<MessageDetails> _messages = new List<MessageDetails>()
        {
            new MessageDetails()
            {
                Sender = _users[1],
                Receiver = _users[2],
                SentDate = DateTime.Now.AddHours(-5),
                IsReceived = true,
                Content = "Coucou Kim!  J'ai un nouveau film, veux-tu en faire parti?"
            },
            new MessageDetails()
            {
                Sender = _users[2],
                Receiver = _users[1],
                SentDate = DateTime.Now.AddHours(-3),
                IsReceived = true,
                Content = "Bruce you know I don't like action films"
            },
            new MessageDetails()
            {
                Sender = _users[1],
                Receiver = _users[2],
                SentDate = DateTime.Now.AddHours(-1),
                IsReceived = false,
                Content = "That's a shame."
            }
        };




        public IActionResult Index()
        {
            //Here the view doesn't correspond to the name of the action
            //return View("IndexOld");
            Title = "Acceuil";
            DemoDynamic();
            return View();
        }

        [Route("Demo/Table/{nb}")]
        public IActionResult Table(int nb)
        {
            Title = $"Table de { nb }";
            ViewData["table"] =nb; //contains the information of the variable table in Table.cshtml
            return View();
        }

        //Showing that Viewbag and viewdata table are the same object:
        [Route("Demo/DynamicTable/{nb}")]
        public IActionResult DynamicTable(int nb)
        {
            Title = $"Table de { nb }";
            ViewBag.table = nb; //contains the information of the variable table in Table.cshtml
            return View("Table");
        }

        [NonAction] 
        public void DemoDynamic()
        {
            dynamic varDynamic;
            varDynamic = "Ceci est une valeur de type string";
            Console.WriteLine(varDynamic.Substring(0,5));
            varDynamic = true;
            if(varDynamic) Console.WriteLine($"c'est vrai");
            varDynamic = 3.141529;
            Console.WriteLine(varDynamic * 30);
        }

        [Route("Demo/SaveData/{data}")]
        public IActionResult SaveData(string data)
        {
            TempData["data"] = data;
            return View();
        }

        public IActionResult ShowData()
        {
            if (TempData.ContainsKey("data"))
            {
                TempData.Keep("data");
            }
            return View();
        }

        public IActionResult ModelsDemoProfil(int id)
        {
            //to show the details of the user:
            if (!_users.ContainsKey(id))
            {
                return RedirectToAction(nameof(Index));
            }
            PersonneDetails model = _users[id];
            return View(model);
        }

        public IActionResult ModelsDemoConversation()
        {
            IEnumerable<MessageDetails> model =_messages;
            if (model is null|| model.Count() == 0) return RedirectToAction(nameof(Index));  
            //The below commented is what appeared before the above.
            //MessageDetails? model = _messages.SingleOrDefault();//to take the first value if there is one
            //if(model is null) return RedirectToAction(nameof(Index));
            return View(model);
        }

    }
}
