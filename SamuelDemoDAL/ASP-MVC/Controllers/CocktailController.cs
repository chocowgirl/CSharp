using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Common.Repositories;
using ASP_MVC.Mappers;
using ASP_MVC.Models.Cocktail;
using ASP_MVC.Models.User;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

//using BLL.Services;
//Above commented b/c of 

//using BLL.Entities;



namespace ASP_MVC.Controllers
{

    public class CocktailController : Controller
    {
        private ICocktailRepository<BLL.Entities.Cocktail> _cocktailService;


        //Injection de dependances below, remember to go to program.cs of the console and add builder.Services related to ICocktailRepository and both BLL and DAL services
        public CocktailController(ICocktailRepository<BLL.Entities.Cocktail> cocktailService)
        {
            _cocktailService = cocktailService;
        }


        // GET: CocktailController
        public ActionResult Index()
        {
            try
            {
                IEnumerable<CocktailListItem> model = _cocktailService.Get().Select(bll => bll.ToListItem());
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }


        // GET: CocktailController/Details/5
        //********Here we have also to create the ToDetails function as it applies to Cocktail in the MVC mapper
        public ActionResult Details(Guid id)
        {
            try
            {
                CocktailDetails model = _cocktailService.Get(id).ToDetails();
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }


        // ***Here we generate the empty form to create a cocktail
        // GET: CocktailController/Create
        public ActionResult Create()
        {
            return View();
        }



        //**** Here we treat the filled-out create-cocktail form after someone clicks submit
        // POST: CocktailController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CocktailCreateForm form)
        {
            try
            {
                if (!ModelState.IsValid) throw new ArgumentException(nameof(form));
                Guid id = _cocktailService.Insert(form.ToBLL()); //mapping needed to do this -> look in MVC mapper for details.
                //The above "Guid id =" takes the id that is the REAL one given from the DB and uses this to show the details of the newly created cocktail below.
                return RedirectToAction(nameof(Details), new {id = id});
            }
            catch
            {
                return View();
            }
        }



        // GET: CocktailController/Edit/5
        public ActionResult Edit(Guid id)
        {
            try
            {
                CocktailEditForm model = _cocktailService.Get(id).ToEditForm();//Get retrieves a user BLL, which needs to be mapped by the mapper of MVC...
                //with the .ToEditForm() we call the conversion function from the MVC mapper to pass the correct info in the correct format
                return View(model);
            }
            catch (Exception)
            {

                return RedirectToAction("Error", "Home");
            }
        }



        // POST: CocktailController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CocktailController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CocktailController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
