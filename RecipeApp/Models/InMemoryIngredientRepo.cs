using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class InMemoryIngredientRepo : IIngredientRepo
    {

        public IEnumerable<Ingredient> AllIngredients =>
          new List<Ingredient>
          {

                new Ingredient { Id = 1, Name ="Minced Meat", ShelfLifeDays = 7 , CaloriesPer100G = 125 , CO2Per100G = 20},
                new Ingredient { Id = 2, Name ="Parmagianno", ShelfLifeDays = 50 , CaloriesPer100G = 85 , CO2Per100G = 10},
                new Ingredient { Id = 3, Name ="Spaghetti", ShelfLifeDays = 400 , CaloriesPer100G = 30 , CO2Per100G = 4},
                new Ingredient { Id = 4, Name ="Tomato", ShelfLifeDays = 12 , CaloriesPer100G = 15 , CO2Per100G = 10}
          };
        public IEnumerable<Ingredient> GetAllIngredients => throw new NotImplementedException();

        public Ingredient GetIngredientById(int ingredientId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Ingredient> IIngredientRepo.AllIngredients()
        {
            throw new NotImplementedException();
        }
    }
}
