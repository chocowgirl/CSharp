using ASP_MVC.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using BLL.Services; //Commented b/c of 
using ASP_MVC.Mappers;
//using BLL.Entities;
using Common.Repositories;

namespace ASP_MVC.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository<BLL.Entities.User> _userService;


        public UserController(IUserRepository<BLL.Entities.User> userService)
        {
            _userService =  userService;
        }


        // GET: UserController
        public ActionResult Index()
        {
            try
            {
                IEnumerable<UserListItem> model = _userService.Get().Select(bll => bll.ToListItem());
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }


        // GET: UserController/Details/5
        //********Here we have created the ToDetails funciton in the MVC mapper
        public ActionResult Details(Guid id)
        {
            try
            {
                UserDetails model = _userService.Get(id).ToDetails();
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }


        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserCreateForm form)
        {
            try
            {
                if (!form.Consent) ModelState.AddModelError(nameof(form.Consent), "You have to read and accept the terms and conditions of service");
                if (!ModelState.IsValid) throw new ArgumentException();
                Guid id = _userService.Insert(form.ToBLL()); //mapping needed to do this -> look in MVC mapper for details.
                //The above "Guid id =" takes the id that is the REAL one given from the DB and uses this to show the details of the newly created user below. 
                return RedirectToAction(nameof(Details), new {id = id});
            }
            catch
            {
                return View();
            }
        }


        // GET: UserController/Edit/5
        public ActionResult Edit(Guid id)
        {
            try
            {
                UserEditForm model = _userService.Get(id).ToEditForm();//Get retrieves a user BLL, which needs to be mapped by the mapper of MVC...
                //with the .ToEditForm() we call the conversion function from the MVC mapper to pass the correct info in the correct format
                return View(model);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home");
            }
        }


        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, UserEditForm form)
        {
            try
            {
                if(!ModelState.IsValid)throw new ArgumentException(nameof(form));
                _userService.Update(id, form.ToBLL());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Edit), new {id = id});
            }
        }


        // GET: UserController/Delete/5
        public ActionResult Delete(Guid id)
        {
            try
            {
                UserDelete model = _userService.Get(id).ToDelete();
                return View(model);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home");
            }
        }



        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, UserDelete form)
        {
            try
            {
                //because there is not a real form to validate the model state of, no verif of it's ModelState to do here.
                _userService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Edit), new { id = id });
            }
        }
    }
}
