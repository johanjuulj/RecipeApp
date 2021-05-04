using Microsoft.AspNetCore.Mvc;
using RecipeApp.Models;
using RecipeApp.ViewModels;

namespace RecipeApp.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IRecipeRepo _recipeRepository;

        public RecipeController(IRecipeRepo recipeRepo)
        {
            _recipeRepository = recipeRepo;

        }

        public ViewResult List()
        {
            RecipeListViewModel recipeListViewModel = new RecipeListViewModel();
            recipeListViewModel.Recipes = _recipeRepository.GetAllRecipes;

            return View(recipeListViewModel);
        }

        public IActionResult Details(int id)
        {
            var recipe = _recipeRepository.GetRecipeById(id);

            if (recipe == null) return NotFound();

            return View(recipe);
        }
        public ViewResult Index()
        {
            
            return View(_recipeRepository.GetAllRecipes);
        }

    }
}
