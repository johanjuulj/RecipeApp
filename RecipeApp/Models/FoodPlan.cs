using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class FoodPlan 
    {
        private readonly AppDbContext _db;

        public string FoodPlanId { get; set; }

        public List<FoodPlanRecipe> FoodPlanRecipes { get; set; } 

        

        private FoodPlan(AppDbContext db)
        {
            _db = db;
        }

        public static FoodPlan GetPlan(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<AppDbContext>();

            string planId = session.GetString("PlanId") ?? Guid.NewGuid().ToString();

            session.SetString("PlanId", planId);

            return new FoodPlan(context) { FoodPlanId = planId };
        }

        public void AddToPlan(Recipe recipe, int amount)
        {
            var foodPlanRecipe =
                    _db.FoodPlanItems.SingleOrDefault(
                        x => x.Recipe.Id == recipe.Id && x.FoodPlanId == FoodPlanId);

            if (foodPlanRecipe == null)
            {
                foodPlanRecipe = new FoodPlanRecipe
                {
                    FoodPlanId = FoodPlanId,
                    Recipe = recipe,
                    //CO2 = 1,
                    Amount = 1
                    
                };

                _db.FoodPlanItems.Add(foodPlanRecipe);
            }
            else
            {
                foodPlanRecipe.Amount++;
            }
            _db.SaveChanges();
        }

        public int RemovefromPlan(Recipe recipe)
        {
            var foodPlanItem =
                    _db.FoodPlanItems.SingleOrDefault(
                        x => x.Recipe.Id == recipe.Id && x.FoodPlanId == FoodPlanId);

            var localAmount = 0;

            if (foodPlanItem != null)
            {
                if (foodPlanItem.Amount > 1)
                {
                    foodPlanItem.Amount--;
                    localAmount = foodPlanItem.Amount;
                }
                else
                {
                    _db.FoodPlanItems.Remove(foodPlanItem);
                }
            }

            _db.SaveChanges();

            return localAmount;
        }

        public int Total()
        {
            int localTotal = 0;
            if (FoodPlanRecipes != null)
            {

                foreach (var x in FoodPlanRecipes)
                {
                   
                    
                    
                    localTotal = localTotal + x.Amount;
                }
            }
            return localTotal;
        }

        public List<FoodPlanRecipe> GetFoodPlanRecipes()
        {
            return FoodPlanRecipes ??
                   (FoodPlanRecipes =
                       _db.FoodPlanItems.Where(c => c.FoodPlanId == FoodPlanId)
                           .Include(s => s.Recipe)
                           .ToList());
        }

        public void ClearPlan()
        {
            var cartItems = _db
                .FoodPlanItems
                .Where(cart => cart.FoodPlanId  == FoodPlanId);

            _db.FoodPlanItems.RemoveRange(cartItems);

            _db.SaveChanges();
        }

       

       

        //add sum function to get full co2 output of foodplan
        //public decimal GetFoodPlanTotal()
        //{
        //    var total = _db.FoodPlanItems.Where(c => c.FoodPlanId == FoodPlanId)
        //        .Select(c => c.Recipe.Price * c.Amount).Sum();
        //    return total;
        //}

    }
}
