using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeApp.Models;
using RecipeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepo;
        private readonly FoodPlan _foodPlan;
        private AppDbContext _appDbContext;

        public OrderController(IOrderRepository orderRepo, FoodPlan foodPlan, AppDbContext appDbContext)
        {
            _orderRepo = orderRepo;
            _foodPlan = foodPlan;
            _appDbContext = appDbContext; 
        }
        [HttpGet]
        public IActionResult CheckOut()
        {
            
            OrderCheckOutViewModel orderCheckOutViewModel = new OrderCheckOutViewModel()
            {
                Order = null,
                RecipeList = _foodPlan.GetFoodPlanRecipes(),
              
                
            };
           


            List<RecipeIngredient> localList = new List<RecipeIngredient>();
            foreach (var recipe in _foodPlan.GetFoodPlanRecipes())
            {

                var sRecipeIngredients = _appDbContext.RecipeIngredients.
                 Include(i => i.Ingredient).
                 Where(ri => ri.RecipeId == recipe.Recipe.Id).ToList();
                
                
                foreach (var ingred in sRecipeIngredients)
                {
                    int indexer = localList.FindIndex(f => f.IngredientId == ingred.IngredientId);
                    if (indexer >= 0)
                    {
                        
                        localList[indexer].WeightofIngredient = localList[indexer].WeightofIngredient + ingred.WeightofIngredient;
                        //add y's weight to local lists version
                    }
                    else
                    {
                        localList.Add(ingred);
                    }
                    
            }


                
            }
          

            decimal localCO2 = 0;
            foreach (var i in localList)
            {



                decimal co2footprint = (i.WeightofIngredient / 100) * i.Ingredient.TotalKgCo2eq;
                localCO2 = localCO2 + co2footprint;

            }

            orderCheckOutViewModel.totalCO2 = localCO2;
            orderCheckOutViewModel.FoodPlanRecipeIngredients = localList;
            return View(orderCheckOutViewModel);
        }

        [HttpPost]
        public IActionResult CheckOut(Order order)
        {


            var recipes = _foodPlan.GetFoodPlanRecipes();
            _foodPlan.FoodPlanRecipes = recipes;

            if (_foodPlan.FoodPlanRecipes.Count == 0)
            {
                ModelState.AddModelError("", "You don't have a food plan ready, add some recipes first");

            }
            if (ModelState.IsValid)
            {
                _orderRepo.CreateOrder(order);
                _foodPlan.ClearPlan();
                return RedirectToAction("CheckOutComplete");
            }
            return View(order);


        }
        public IActionResult CheckOutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order. We hope you enjoye your climate improved weekly meal plan";
            return View();
        }
    }
}
