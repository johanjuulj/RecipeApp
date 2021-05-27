using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class Recipe
    {
        [BindNever]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a recipe name"), StringLength(80), MinLength(2)]
        [Display(Name = "Recipe Name")]
        public string Name { get; set; }

        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        //insert dictionary on how to prepare the food

        //allergy information, should this be pulled from ingredient list

        public decimal Price { get; set; }

        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "What cuisine is your recipe from?")]
        [Display(Name = "Cuisine")]
        public Cuisine Kitchen { get; set; }

        //ingredientlist id
        //public int IngredientId { get; set; }
        ////add process/amount to future versions for now we only calculate co2 footprint, 
        //[Required(ErrorMessage = "Recipes allways have ingredients, please add some")]
        //[Display(Name = "Ingredients")]
        //public IDictionary<RecipeIngredient, int> RecipeIngredients = new Dictionary<RecipeIngredient, int>();



        [Display(Name = "Ingredients")]
        public List<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();

            

    }
}
