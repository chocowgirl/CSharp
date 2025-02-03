using Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Mappers;
//using DAL.Entities;

//using DAL.Services;
//using D = DAL.Services;
//The above line creates an alias (D) for DAL.Services

//using D = DAL.Entities;


//B:c you are in the 
namespace BLL.Services
{
    public class CocktailService : ICocktailRepository<BLL.Entities.Cocktail>
    {
        private ICocktailRepository<DAL.Entities.Cocktail> _service;
        //Above we call the DAL.Entities service because we'll need it to retrieve and then convert to BLL

        public CocktailService(ICocktailRepository<DAL.Entities.Cocktail> cocktailService)
        {
            _service = cocktailService;
        }

        public IEnumerable<BLL.Entities.Cocktail> Get()
        {
            return _service.Get().Select(dal => dal.ToBLL());
            //throw new NotImplementedException();
        }

        public BLL.Entities.Cocktail Get(Guid cocktail_id)
        {
            return _service.Get(cocktail_id).ToBLL();
        }

        public Guid Insert(BLL.Entities.Cocktail cocktail)
        {
            return _service.Insert(cocktail.ToDAL());
        }

        public void Delete(Guid cocktail_id)
        {
            _service.Delete(cocktail_id);
        }


        public void Update(Guid cocktail_id, BLL.Entities.Cocktail cocktail)
        {
            _service.Update(cocktail_id, cocktail.ToDAL());
        }
    }
}
