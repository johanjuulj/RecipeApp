using Microsoft.AspNetCore.Http;
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

      

        public ViewResult List()
        {
            RecipeListViewModel recipeListViewModel = new RecipeListViewModel();
            recipeListViewModel.Recipes = _recipeRepository.GetAllRecipes();

            return View(recipeListViewModel);
        }
        //remove this and rename List() Index()
        public ViewResult Index()
        {

            return View(_recipeRepository.GetAllRecipes());
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

            

            foreach (Ingredient i in addIngredientViewModel.Ingredients)
            {
                addIngredientViewModel.RecipeList.Add(i.Id.ToString(), 1); ;
            }
            
            

            return View(addIngredientViewModel);
        }
        [HttpPost]
        public RedirectToActionResult AddedIngredients(AddIngredientViewModel model)
        {
            Console.Write(model.NumerOfIngredients);
          

            foreach (KeyValuePair<string, int> amount in model.RecipeList)
            {
                Console.WriteLine("Key: {0}, Value: {1}", amount.Key, amount.Value);


            }


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
            List<RecipeIngredient> localRecipeIngredients = _appDbContext.RecipeIngredients.
                Include(i => i.Ingredient).
                Where(ri => ri.RecipeId == id).ToList();

            decimal localWeight = 0;
            foreach (var i in localRecipeIngredients)
            {
                
                

                decimal co2footprint = (i.WeightofIngredient / 100) * i.Ingredient.CO2Per100G;
                localWeight = localWeight + co2footprint;
                
            }
            
            // decimal localWeight = 0;
            //which get recipe is better?
            //Recipe rECIPE = _appDbContext.Recipes.Single(r => r.Id == id);
            var recipe = _recipeRepository.GetRecipeById(id);

            if (recipe == null) return NotFound();

            RecipeDetailsViewModel recipeDetailsViewModel = new RecipeDetailsViewModel()
            {
                Recipe = recipe,
                numberOfRecipes = 0,
                recipeIngredients = localRecipeIngredients,
                totalCO2 = localWeight

            };

            
            Console.WriteLine("now Recipe ID and name are " + recipeDetailsViewModel.Recipe.Id + recipeDetailsViewModel.Recipe.Name);
            return View(recipeDetailsViewModel);
        }

        // /Recipe/AddItem/?int
        public IActionResult AddItem(int id)
        {
            Recipe recipe = _appDbContext.Recipes.Single(r => r.Id == id);

            List<Ingredient> ingredients = _ingredientRepo.GetAllIngredients.ToList();

            //List<Ingredient> ingredients = _appDbContext.Ingredients.ToList();

            return View(new AddRecipeIngredientViewModel(recipe,ingredients));
        }

        [HttpPost]
        public IActionResult AddItem(AddRecipeIngredientViewModel model)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine(model.grams);


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
                        //add weight here maybe?
                    };
                    _appDbContext.RecipeIngredients.Add(recipeIngredient);
                    _appDbContext.SaveChanges();
                }
                //return Redirect(string.Format("Menu/ViewMenu/{0}", model);
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
