using Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using BLL.Entities;
//using BLL.Mappers;

//using DAL.Services;
//using D = DAL.Services;
//The above line creates an alias (D) for DAL.Services

//using D = DAL.Entities;



namespace BLL.Services
{
    public class CocktailService : ICocktailRepository<Cocktail>
    {
        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cocktail> Get()
        {
            throw new NotImplementedException();
        }

        public Cocktail Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Guid Insert(Cocktail cocktail)
        {
            throw new NotImplementedException();
        }

        public void Update(Guid id, Cocktail cocktail)
        {
            throw new NotImplementedException();
        }
    }
}
