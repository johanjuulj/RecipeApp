using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.ViewModels
{
    public class OrderCheckOutViewModel
    {
        public  Order Order  { get; set; }
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public decimal totalCO2 { get; set; }

        public List<FoodPlanRecipe> RecipeList { get; set; }

        public List<RecipeIngredient> FoodPlanRecipeIngredients { get; set; } = new List<RecipeIngredient>();

           
    }
}
