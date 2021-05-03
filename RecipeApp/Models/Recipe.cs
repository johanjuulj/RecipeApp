using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required, StringLength(80), MinLength(2)]
        public string Name { get; set; }

        public string ShortDescription { get; set; }

        //insert dictionary on how to prepare the food

        //allergy information, should this be pulled from ingredient list

      //  public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public Cuisine Kitchen { get; set; }
        
        //public Ingredient MainIngredient { get; set; }
        //public IDictionary<Ingredient, int> IngredientList = new Dictionary<Ingredient, int>();
    }
}
