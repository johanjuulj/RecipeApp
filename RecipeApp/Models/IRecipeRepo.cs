using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public interface IRecipeRepo
    {
        //IEnumerable<Recipe> GetAllRecipes { get; }
        IEnumerable<Recipe> GetAllRecipes();

        //IEnumerable<Recipe> SearchRecipes { get; }
        Recipe GetRecipeById(int recipeId);

        void CreateRecipe(Recipe recipe);
        void RemoveRecipe(Recipe recipe);

    }
}
