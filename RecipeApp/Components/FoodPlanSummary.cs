using Microsoft.AspNetCore.Mvc;
using RecipeApp.Models;
using RecipeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Components
{
    public class FoodPlanSummary : ViewComponent
    {
        private readonly FoodPlan _foodPlan;

        public FoodPlanSummary(FoodPlan foodPlan)
        {
            _foodPlan = foodPlan;
        }

        public IViewComponentResult Invoke()
        {
            var recipes = _foodPlan.GetFoodPlanRecipes();
            _foodPlan.FoodPlanRecipes = recipes;

            var foodPlanViewModel = new FoodPlanViewModel
            {
                FoodPlan = _foodPlan,
            };
            return View(foodPlanViewModel);
        }
    }
}
