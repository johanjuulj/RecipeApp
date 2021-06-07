using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.ViewModels
{
    public class RecipeDetailsViewModel
    {
        public Recipe Recipe { get; set; }

        public int recipeId { get; set; }
        public int ingredientId { get; set; }

        public int numberOfRecipes { get; set; }
        [DisplayFormat(DataFormatString = "{0:n0}", ApplyFormatInEditMode = true)]
        public decimal totalCO2 { get; set; }

        public List<RecipeIngredient> recipeIngredients { get; set; }
    }
}
