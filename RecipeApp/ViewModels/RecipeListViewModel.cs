using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.ViewModels
{
    public class RecipeListViewModel
    {
        public IEnumerable<Recipe> Recipes { get; set; }
        public string yello { get; set; }
    }
}
