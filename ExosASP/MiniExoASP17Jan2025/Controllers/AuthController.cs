using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MiniExoASP17Jan2025.Handlers;
using MiniExoASP17Jan2025.Models.Auth;
using System.ComponentModel.DataAnnotations;

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


        //*****The below allows us to show the empty form (html view of the form).
        [HttpGet("Auth/Register")]
        public IActionResult Register()
        {
            Title += "-S'enregistrer";
            return View();
        }

        //*****The below allows us to Post the form infos.
        [HttpPost("Auth/Register")]
        public IActionResult Register(RegisterForm form)
        {
            //Subtitle = "- S'enregistrer";
            Title += "-S'enregistrer";

            //if (TempData.ContainsKey("message"))
            //{
            //    return RedirectToAction(nameof(Login));
            //}
            //else
            //{
            //    TempData["message"] = "Vous etes maintenant enregistré!";
            //    return View();
            //}
            try
            {
                //Here we do the checks that weren't simple to add into the Model
                ModelState.RequiredAge(form.Birthday, nameof(form.Birthday));
                ModelState.RequiredLowerCase(form.Password, nameof(form.Password));
                ModelState.RequiredUpperCase(form.Password, nameof(form.Password));
                ModelState.RequiredNumber(form.Password, nameof(form.Password));
                ModelState.RequiredSymbol(form.Password, nameof(form.Password));

                if (!ModelState.IsValid) throw new ArgumentException();
                //Envois des informations en DB
                TempData["message"] = "You are now registered";
                return RedirectToAction(nameof(Login));
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }



    }
}
