using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly FoodPlan _foodPlan;

        public OrderRepository(AppDbContext appDbContext, FoodPlan foodPlan)
        {
            _appDbContext = appDbContext;
            _foodPlan = foodPlan;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            var foodPlan = _foodPlan.FoodPlanRecipes;
            order.OrderTotal = _foodPlan.Total();
                

            order.OrderDetails = new List<OrderDetail>();
            //adding the order with its details

            foreach (var foodPlanRecipe in foodPlan)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = foodPlanRecipe.Amount,
                    RecipeId = foodPlanRecipe.Recipe.Id,
                    Price = foodPlanRecipe.Recipe.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            _appDbContext.Orders.Add(order);

            _appDbContext.SaveChanges();
        }
    }
}
