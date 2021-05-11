using Microsoft.AspNetCore.Mvc;
using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepo;
        private readonly FoodPlan _foodPlan;

        public OrderController(IOrderRepository orderRepo, FoodPlan foodPlan)
        {
            _orderRepo = orderRepo;
            _foodPlan = foodPlan;
        }
        public IActionResult CheckOut()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            var recipes = _foodPlan.GetFoodPlanRecipes();
            _foodPlan.FoodPlanRecipes = recipes;

            if(_foodPlan.FoodPlanRecipes.Count == 0)
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
