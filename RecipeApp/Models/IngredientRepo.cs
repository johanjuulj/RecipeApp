using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class IngredientRepo : IIngredientRepo
    {
        private readonly AppDbContext _db;

        public IngredientRepo(AppDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Ingredient> GetAllIngredients
        {
            get
            {

                //se code snippet on how to .Include ingredients
                return _db.Ingredients;
            }
        }

        public Ingredient GetIngredientById(int ingredientId)
        {

            return _db.Ingredients.FirstOrDefault(r => r.Id == ingredientId);

        }

        public IEnumerable<Ingredient> AllIngredients()
        {

            return _db.Ingredients;

        }
    }
}
