using Microsoft.AspNetCore.Mvc.Rendering;
using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.ViewModels
{
    public class AddRecipeIngredientViewModel
    {
        public Recipe Recipe { get; set; }
        public List<SelectListItem> Ingredients { get; set; }

        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public decimal grams { get; set; }

        public int RecipeId { get; set; }

        public int IngredientId { get; set; }

        public AddRecipeIngredientViewModel() { }
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
