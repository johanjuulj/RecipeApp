using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class RecipeRepo : IRecipeRepo
    {
        private readonly AppDbContext _db;

        public RecipeRepo(AppDbContext db)
        {
            _db = db;
        }


        public IEnumerable<Recipe> GetAllRecipes 
        { 
            get
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
