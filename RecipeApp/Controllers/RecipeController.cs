using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecipeApp.Models;
using RecipeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RecipeApp.Controllers
{
    public class RecipeController : Controller


    {

        private readonly IHtmlHelper htmlHelper;
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

       //figure out whether this shoulld be get or post and how to pass information here [HttpPost]
       [HttpPost]
        public ActionResult AddIngredient(RecipeDetailsViewModel model)
        {

            

          
            //checking

            AddIngredientViewModel addIngredientViewModel = new AddIngredientViewModel();
            addIngredientViewModel.Recipe = _recipeRepository.GetRecipeById(model.recipeId);

            addIngredientViewModel.Ingredients = _ingredientRepo.GetAllIngredients;
            addIngredientViewModel.NumerOfIngredients = model.numberOfRecipes;
            
            return View(addIngredientViewModel);
        }
        [HttpPost]
        public RedirectToActionResult AddedIngredients(AddIngredientViewModel model)
        {
            Console.Write(model.NumerOfIngredients);


            return RedirectToAction("List");
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
            
            var selectedRecipe = _recipeRepository.GetAllRecipes().FirstOrDefault(p => p.Id == recipeId);

            if (selectedRecipe != null)
            {
                
                _recipeRepository.RemoveRecipe(selectedRecipe);
            }
            
            return RedirectToAction("List");
        }



        public IActionResult Details(int id)
        {

            var recipe = _recipeRepository.GetRecipeById(id);

            if (recipe == null) return NotFound();

            RecipeDetailsViewModel recipeDetailsViewModel = new RecipeDetailsViewModel()
            {
                Recipe = recipe,
                numberOfRecipes = 0

            };

            
            Console.WriteLine("now Recipe ID and name are " + recipeDetailsViewModel.Recipe.Id + recipeDetailsViewModel.Recipe.Name);
            return View(recipeDetailsViewModel);
        }
        public ViewResult Index()
        {
            
            return View(_recipeRepository.GetAllRecipes());
        }

    }
}
