using Demo_ASP1.Handlers;
using Demo_ASP1.Models;
using Demo_ASP1.Models.Demo;
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


        //The below allows us to show the empty form (html view of the form).
        [HttpGet("Demo/Forms")]
        public IActionResult FormsDemo()
        {
            return View();
        }

        //The below allows us to treat information placed into form and submitted by the user
        //the parameter form is the information from the form.
        //After the action is done it redirects to Index of DemoController
        //In order for the browser to understand the difference between reading (getting) and posting the form, we put [HttpPost] and [HttpGet] to distinguish the identically named methods

        [HttpPost("Demo/Forms")]
        public IActionResult FormsDemo(FormsDemoForm form)
        {
            try
            {
                //if (string.IsNullOrWhiteSpace(form.LastName))
                //{
                //    ModelState.AddModelError(nameof(form.LastName), "Le champs 'Nom' est requis.");
                //}
                //Instead of putting the above, we now put the line below and let our validation handler treat it.
                //ValidationHandler.Required(ModelState, form.LastName, nameof(form.LastName));

                //if(form.LastName.Length <= 1)
                //{
                //    ModelState.AddModelError(nameof(form.LastName), "Le champ Nom doit contenir un min de 2 caractères");
                //}
                //Instead of putting the above, we now put the line below and let our validation handler treat it.
                //ValidationHandler.Required(ModelState, form.FirstName, nameof(form.FirstName));

                //if(form.LastName.Length > 64){
                //    ModelState.AddModelError(nameof(form.LastName), "Length can't exceed more than 64 characters");
                //Instead of putting the above, we now put the line below and let our validation handler treat it.
                //ValidationHandler.Required(ModelState, form.BirthDate, nameof(form.BirthDate));
                //
                //
                //

                //ModelState.Required(form.LastName, nameof(form.LastName));
                //ModelState.Required(form.FirstName, nameof(form.FirstName));
                //ModelState.Required(form.BirthDate, nameof(form.BirthDate));
                //ModelState.MinLength(form.LastName, nameof(form.LastName), 2);
                //ModelState.MinLength(form.FirstName, nameof(form.FirstName), 2);
                //ModelState.MaxLength(form.LastName, nameof(form.LastName), 64);
                //ModelState.MaxLength(form.FirstName, nameof(form.FirstName), 64);
                //Made redundant by the use of validation attributes in the FormsDemoForm.cs class

                if (!ModelState.IsValid) throw new ArgumentException();
                PersonneDetails data = new PersonneDetails()
                {
                    LastName = form.LastName,
                    FirstName = form.FirstName,
                    BirthDate = form.BirthDate
                };
                _users.Add(_users.Keys.Max() + 1, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        public IActionResult DLayout()
        {
            return View();
        }

    }
}
