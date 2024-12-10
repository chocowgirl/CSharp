using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo06Operators.Models
{
    public class Recette
    {
        private Dictionary<Ingredient, int> _ingredients;
        public string Nom {  get; private set; }

        public Ingredient[] Ingredients
        {
            get { return _ingredients.Keys.ToArray(); }
        }
        
        
        
        public int ValeurNutritiveTotal
        {
            get
            {
                int result = 0;
                foreach (KeyValuePair<Ingredient, int> kvp in _ingredients)
                {
                    result += (kvp.Key.ValeurNutritive * kvp.Value);
                }
                return result;
            }
        }


        public Recette(string nom)
        {
            Nom = nom;
            _ingredients = new Dictionary<Ingredient, int>();
        }

        public void AjouterIngredient(Ingredient ingredient)
        {
            if(_ingredients.ContainsKey(ingredient)) _ingredients[ingredient] += 1;
            else _ingredients.Add(ingredient, 1);
        }

    }
}
