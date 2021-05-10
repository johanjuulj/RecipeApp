using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class RecipeRepo : IRecipeRepo
    {
        private readonly AppDbContext _db;
        private readonly FoodPlan _foodPlan;

        public RecipeRepo(AppDbContext db, FoodPlan foodPlan)
        {
            _db = db;
            _foodPlan = foodPlan;
        }

        public void CreateRecipe(Recipe recipe)
        {
            //if recipe name /ingredients match existing recipes ask whether a new one should be created

            var localRecipe = recipe;

            _db.Recipes.Add(localRecipe);
            _db.SaveChanges();

        }


        public void RemoveRecipe(Recipe recipe)
        {
            var localRecipe =
                    _db.Recipes.SingleOrDefault(
                        s => s.Id == recipe.Id);

            
            _db.Recipes.Remove(localRecipe);
            _db.SaveChanges();

            
        }
        //public void CreateOrder(Recipe recipe)
        //{


        //    var foodPlanRecipes = _foodPlan.FoodPlanRecipes;
        //    recipe.OrderTotal = _foodPlan.GetShoppingCartTotal();

        //    recipe.OrderDetails = new List<OrderDetail>();
        //    //adding the order with its details

        //    foreach (var foodPlan in foodPlanRecipes)
        //    {
        //        var orderDetail = new OrderDetail
        //        {
        //            Amount = shoppingCartItem.Amount,
        //            PieId = shoppingCartItem.Pie.PieId,
        //            Price = shoppingCartItem.Pie.Price
        //        };

        //        recipe.OrderDetails.Add(orderDetail);
        //    }

        //    _appDbContext.Orders.Add(recipe);

        //    _appDbContext.SaveChanges();
        //}

        public IEnumerable<Recipe> GetAllRecipes() 
        { 
            
            {

                //se code snippet on how to .Include ingredients
                return _db.Recipes;
            }
        }



        public Recipe GetRecipeById(int recipeId)
        {
         
                return _db.Recipes.FirstOrDefault(r => r.Id == recipeId);
           
        }

        
    }
}
