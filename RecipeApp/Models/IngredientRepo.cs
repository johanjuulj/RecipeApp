using RecipeApp.csvReader;
using System;
using System.Collections.Generic;
using System.IO;
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

       

        public async Task<List<Ingredient>> LoadNewIngredients()
        {
            //move stuff to DB context
            var file = new FileInfo(@"C:\repo\ingredients.xlsx");

            Reader parser = new Reader();
            List<Ingredient> loadedIngredients = await parser.LoadIngredientlData(file);

            return loadedIngredients;
            
        }

        public void CreateIngredient(Ingredient ingredient)
        {
            //if recipe name /ingredients match existing recipes ask whether a new one should be created

            var localIngredient = ingredient;

            _db.Ingredients.Add(localIngredient);
            _db.SaveChanges();

        }
        public IEnumerable<Ingredient> GetAllIngredients
        {
            get
            {
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
