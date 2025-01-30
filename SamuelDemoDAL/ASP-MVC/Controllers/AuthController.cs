using ASP_MVC.Models.Auth;
using BLL.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC.Controllers
{
    public class AuthController : Controller
    {
        private IUserRepository<BLL.Entities.User> _userService; //by right click on _userService here we can easily inject the dependances by automatically doing ctor from it.


        public AuthController(IUserRepository<User> userService)
        {
            _userService = userService;
        }


        public IActionResult Index()
        {
            return RedirectToAction(nameof(Login));
        }



        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(AuthLoginForm form)
        {
            try
            {
                if (!ModelState.IsValid) throw new ArgumentException(nameof(form));
                Guid id = _userService.CheckPassword(form.Email, form.Password);
                //****Here we will define the session variable****
                return RedirectToAction("Details", "User", new {id = id});
            }
            catch (Exception)
            {
                return View();
            }
        }

    }
}
