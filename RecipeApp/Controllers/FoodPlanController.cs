using Microsoft.AspNetCore.Mvc;
using RecipeApp.Models;
using RecipeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Controllers
{
    public class FoodPlanController : Controller
    {
        private readonly IRecipeRepo _recipeRepo;
        private readonly FoodPlan _foodPlan;

        public FoodPlanController(IRecipeRepo recipeRepo, FoodPlan foodPlan)
        {
            _recipeRepo = recipeRepo;
            _foodPlan = foodPlan;
        }
        
        public ViewResult Index()
        {
            var recipes = _foodPlan.GetFoodPlanRecipes();
            _foodPlan.FoodPlanRecipes = recipes;

            var foodPlanViewModel = new FoodPlanViewModel
            {
                FoodPlan = _foodPlan,
                //FoodPlanTotal = _foodPlan.GetFoodPlanTotal()
            };

            return View(foodPlanViewModel);

        }

        public RedirectToActionResult AddToFoodPlan(int recipeId)
        {
            
            var selectedRecipe = _recipeRepo.GetAllRecipes().FirstOrDefault(r => r.Id == recipeId);

            if(selectedRecipe != null)
            {
               
                _foodPlan.AddToPlan(selectedRecipe,1);
            }


            return RedirectToAction("Index");
        }




        public RedirectToActionResult RemoveFromFoodPlan(int recipeId)
        {
            
            var selectedRecipe = _recipeRepo.GetAllRecipes().FirstOrDefault(r => r.Id == recipeId);

            if (selectedRecipe != null)
            {
                _foodPlan.RemovefromPlan(selectedRecipe);
            }


            return RedirectToAction("Index");
        }
    }
}
