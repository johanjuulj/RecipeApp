using Microsoft.AspNetCore.Mvc;
using RecipeApp.Models;
using RecipeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApp.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IRecipeRepo _recipeRepository;

        public IIngredientRepo _ingredientRepo { get; }

        public RecipeController(IRecipeRepo recipeRepo, IIngredientRepo ingredientRepo)
        {
            _recipeRepository = recipeRepo;
            _ingredientRepo = ingredientRepo;
        }

        public ViewResult List()
        {
            RecipeListViewModel recipeListViewModel = new RecipeListViewModel();
            recipeListViewModel.Recipes = _recipeRepository.GetAllRecipes();

            return View(recipeListViewModel);
        }
        public IEnumerable<Ingredient> Ingr { get; set; }

        public ViewResult Create()
        {
            //should  this one be made obsolete by including it in CreteNew with an  if statement? 
            RecipeCreateViewModel recipeCreateViewModel = new RecipeCreateViewModel()
            {
                Recipe = null,
                Ingredients = _ingredientRepo.AllIngredients(),
                Kitchen = new Cuisine()

            };
            
            Ingr = _ingredientRepo.AllIngredients();
            
            foreach(var i in Ingr)
            {
                Console.WriteLine(i.Name);
            }
            

            return View(recipeCreateViewModel);
        }

        [HttpPost]
        public ViewResult Create(Recipe recipe)
        {
           




            if (recipe == null)
            {
                ModelState.AddModelError("", "Your recipe is invalid please check your inputs and try again");
            }
           
            _recipeRepository.CreateRecipe(recipe);



            var homeViewModel = new HomeViewModel
            {
                SelectedRecipes = _recipeRepository.GetAllRecipes()

            };
            return View("Views/Home/Index.cshtml", homeViewModel);

        }
        public RedirectToActionResult Remove(int recipeId)
        {
            Console.WriteLine(recipeId);
            var selectedRecipe = _recipeRepository.GetAllRecipes().FirstOrDefault(p => p.Id == recipeId);

            if (selectedRecipe != null)
            {
                Console.WriteLine("not null");
                _recipeRepository.RemoveRecipe(selectedRecipe);
            }
            Console.WriteLine("much null");
            return RedirectToAction("List");
        }



        public IActionResult Details(int id)
        {
            var recipe = _recipeRepository.GetRecipeById(id);

            if (recipe == null) return NotFound();

            return View(recipe);
        }
        public ViewResult Index()
        {
            
            return View(_recipeRepository.GetAllRecipes());
        }

    }
}
