using Microsoft.AspNetCore.Mvc;
using RecipeApp.Models;
using RecipeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRecipeRepo recipeRepo;
        private readonly IIngredientRepo ingredientRepo;
        private readonly AppDbContext appDbContext;
        public HomeController(IRecipeRepo db, IIngredientRepo ingredientRepo, AppDbContext appDbContext)
        {
            recipeRepo = db;

            this.ingredientRepo = ingredientRepo;
            this.appDbContext = appDbContext;

        }
        public async Task<IActionResult> Index()
        {
            var homeViewModel = new HomeViewModel
            {
                SelectedRecipes = recipeRepo.GetAllRecipes()

                

            };

            var x = ingredientRepo.AllIngredients();

            if (x.Count() == 0)
            {
              
                RecipeController controller = new RecipeController(recipeRepo, ingredientRepo,appDbContext);
                await controller.DBUpdate();
                
            }


            return View(homeViewModel);
        }
    }
}
