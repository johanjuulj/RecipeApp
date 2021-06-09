
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        private readonly IRecipeRepo _recipeRepository;

        public IIngredientRepo _ingredientRepo { get; }

        private AppDbContext _appDbContext;

        public RecipeController(IRecipeRepo recipeRepo, IIngredientRepo ingredientRepo, AppDbContext appDbContext)
        {
            _recipeRepository = recipeRepo;
            _ingredientRepo = ingredientRepo;
            _appDbContext = appDbContext;
        }
        public void deleteAll()
        {
            var records = from m in _appDbContext.Ingredients
                          select m;
            foreach (var record in records)
            {
                _appDbContext.Ingredients.Remove(record);
            }
            _appDbContext.SaveChanges();
        }
      
        public async  Task DBUpdate()
        {
            List<Ingredient> localList = await _ingredientRepo.LoadNewIngredients();

            foreach (Ingredient i in localList)
            {
                Ingredient localIngredient = i;
                
                _appDbContext.Ingredients.Add(localIngredient);

            }

            await _appDbContext.SaveChangesAsync();
        }

        public  ViewResult List()
        {
            RecipeListViewModel recipeListViewModel = new RecipeListViewModel();
            recipeListViewModel.Recipes = _recipeRepository.GetAllRecipes();

            
            
            return View(recipeListViewModel);
        }
       
        public ViewResult Index()
        {

            return View(_recipeRepository.GetAllRecipes());
        }



        public ViewResult Create()
        {
            _ingredientRepo.CreateIngredient(new Ingredient { Name = "Oste Snask", Caloriesperkg = 700, TotalKgCo2eq = 42, Category = CategoryDSK.Oils_fatsEdible });
            
            RecipeCreateViewModel recipeCreateViewModel = new RecipeCreateViewModel()
            {
                Recipe = null,
                Ingredients = _ingredientRepo.AllIngredients(),
                Kitchen = new Cuisine()

            };
            
         

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
            List<RecipeIngredient> localRecipeIngredients = _appDbContext.RecipeIngredients.
                Include(i => i.Ingredient).
                Where(ri => ri.RecipeId == id).ToList();

            var recipe = _recipeRepository.GetRecipeById(id);
            if (recipe == null) return NotFound();
            decimal localWeight = 0;
            foreach (var i in localRecipeIngredients)
            {
                decimal co2footprint = (i.WeightofIngredient / 1000) * i.Ingredient.TotalKgCo2eq;
                localWeight = localWeight + co2footprint;     
            }
            RecipeDetailsViewModel recipeDetailsViewModel = new RecipeDetailsViewModel()
            {
                Recipe = recipe,
                numberOfRecipes = 0,
                recipeIngredients = localRecipeIngredients,
                totalCO2 = localWeight  };

            return View(recipeDetailsViewModel);
        }



        // /Recipe/AddItem/?int
        public IActionResult AddItem(int id)
        {
            Recipe recipe = _appDbContext.Recipes.Single(r => r.Id == id);

            List<Ingredient> ingredients = _ingredientRepo.GetAllIngredients.ToList();

           

            return View(new AddRecipeIngredientViewModel(recipe,ingredients));
        }

        [HttpPost]
        public IActionResult AddItem(AddRecipeIngredientViewModel model)
        {
            if (ModelState.IsValid)
            {
               


                var ingredientId = model.IngredientId;
                var recipeId = model.RecipeId;

                IList<RecipeIngredient> existingIngredients = _appDbContext.RecipeIngredients.
                    Where(ri => ri.IngredientId == ingredientId).
                    Where(ri => ri.RecipeId == recipeId).ToList();
                if(existingIngredients.Count == 0)
                {
                    RecipeIngredient recipeIngredient = new RecipeIngredient
                    {
                        Ingredient = _appDbContext.Ingredients.Single(i => i.Id == ingredientId),
                        Recipe = _appDbContext.Recipes.Single(r => r.Id == recipeId),
                        WeightofIngredient = model.grams
                        
                    };
                    _appDbContext.RecipeIngredients.Add(recipeIngredient);
                    _appDbContext.SaveChanges();
                }
                
                return RedirectToAction("List");
            }
            return RedirectToAction("List");
        }

        [HttpPost]
        public RedirectToActionResult RemoveItem(RecipeDetailsViewModel model)
        {
           
            
            var ingredientId = model.ingredientId;
            var recipeId = model.recipeId;
            
            
            var selectedRecipeIngredient = _appDbContext.RecipeIngredients.
                    Where(ri => ri.IngredientId == ingredientId).
                    Where(ri => ri.RecipeId == recipeId).ToList();
            if (selectedRecipeIngredient != null )
            
            {
                if(selectedRecipeIngredient.Count() == 1) {
                    _appDbContext.RecipeIngredients.Remove(selectedRecipeIngredient[0]);

                    _appDbContext.SaveChanges();
                }
                

                
    }

            return RedirectToAction("List");
}


    }
}
