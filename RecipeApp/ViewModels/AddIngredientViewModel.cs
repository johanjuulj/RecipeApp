using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.ViewModels
{
    public class AddIngredientViewModel
    {
        public Recipe Recipe { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }

        public int NumerOfIngredients { get; set; }

        public Dictionary<string, int> RecipeList { get; set; }

        public AddIngredientViewModel()
        {
            RecipeList = new Dictionary<string, int>();
            
    }
        
        
        
       

       

        public AddIngredientViewModel Add(string key, int value)
        {
            RecipeList.Add(key, value);
            return this;
        }
    }
}
