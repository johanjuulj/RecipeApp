using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.ViewModels
{
    public class RecipeCreateViewModel
    {
        
        public Recipe Recipe { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }

        public Cuisine Kitchen { get; set; }
    }
}
