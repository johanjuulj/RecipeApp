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
        private readonly IRecipeRepo _db;

        public HomeController(IRecipeRepo db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                SelectedRecipes = _db.GetAllRecipes()

        };
            return View(homeViewModel);
        }
    }
}
