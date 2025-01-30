﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public interface ICocktailRepository<TCocktail>
    {
        IEnumerable<TCocktail> Get();

        TCocktail Get(Guid id);

        Guid Insert(TCocktail cocktail);

        void Update(Guid id, TCocktail cocktail);

        void Delete(Guid id);
    }
}
