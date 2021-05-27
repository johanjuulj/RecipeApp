using Microsoft.AspNetCore.Mvc.Rendering;
using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.ViewModels
{
    public class AddRecipeIngredientViewModel
    {
        public Recipe Recipe { get; set; }
        public List<SelectListItem> Ingredients { get; set; }

        //public List<Ingredient> Ingredients { get; set; }

        public int RecipeId { get; set; }

        public int IngredientId { get; set; }

        public AddRecipeIngredientViewModel(Recipe recipe, IEnumerable<Ingredient> ingredients )
        {
            Ingredients = new List<SelectListItem>();
            this.Recipe = recipe;
            

            foreach (var ingredient in ingredients)
            {
                Ingredients.Add(new SelectListItem
                {
                    Text = ingredient.Name.ToString(),
                    Value = ingredient.Id.ToString()
                    


                });

            }
        }
    }

}
