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

        public IDictionary<int, int> RecipeList { get; set; }
    }
}
