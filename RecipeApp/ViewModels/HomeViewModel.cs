using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Recipe> SelectedRecipes { get; set; }
    }
}
