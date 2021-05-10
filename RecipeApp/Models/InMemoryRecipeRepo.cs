using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class InMemoryRecipeRepo : IRecipeRepo
    {

        //should probably be a list instead of a method including a list of all
        public IEnumerable<Recipe> GetAllRecipes =>
            new List<Recipe>
            {

                new Recipe { Id = 1, Name ="Bolognese", Kitchen = Cuisine.Italian},
                new Recipe { Id = 2, Name ="Caneloni", Kitchen = Cuisine.Italian},
                new Recipe { Id = 3, Name ="Mac and Cheese", Kitchen = Cuisine.American},
                new Recipe { Id = 4, Name ="Rød Grød med Fløde", Kitchen = Cuisine.Danish}
            };
        
        
        public IEnumerable<Recipe> GetAllRecipes1 => throw new NotImplementedException();

        public void CreateRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public Recipe GetRecipeById(int recipeId)
        {
            return GetAllRecipes.FirstOrDefault(x => x.Id == recipeId);
        }
    }
}
