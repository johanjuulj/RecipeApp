using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.ViewModels
{
    public class FoodPlanViewModel
    {
        public FoodPlan FoodPlan { get; set; }

        public decimal ShoppingCartTotal { get; set; }
    }
}
