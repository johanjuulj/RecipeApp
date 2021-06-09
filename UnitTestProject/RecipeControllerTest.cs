using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using RecipeApp.Controllers;
using RecipeApp.Models;
using System;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestProject
{
    public class RecipeControllerTest
    {
        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }

        [Fact]
        public void List()
        {
            // Arrange
           
            var IReci = A.Fake<IRecipeRepo>();
            var foodPlan = new FoodPlan();

            var controller = new FoodPlanController(IReci, foodPlan);

            // Act
            var result = controller.Index() as IActionResult;

            // Assert
           Assert.NotNull(result);
        }
        //[Fact]
        //public void Details()
        //{
        //    //arange
           //var IReci = A.Fake<IRecipeRepo>();
           //var IIng = A.Fake<IIngredientRepo>();
           //var Db = A.Fake<AppDbContext>();

        //    int count = 5;

        //    var fakeRecipes = A.CollectionOfDummy<Recipe>(count).AsEnumerable();

            
            
        //    A.CallTo(() => IReci.GetRecipeById(count));


        //    var controller = new RecipeController(IReci, IIng, IDb);

        //    // Ingredient ing = new Ingredient { Id = 3, Name = "Fulerod" };

        //    //act
        //    var actionResult = controller.Details(count);

        //    //assert

        //    var result = actionResult.Result as OkObjectResult;
        //}
    }
    
}
