using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public interface IIngredientRepo
    {
        IEnumerable<Ingredient> GetAllIngredients { get; }

        //IEnumerable<Recipe> SearchRecipes { get; }
        Ingredient GetIngredientById(int ingredientId);
        IEnumerable<Ingredient> AllIngredients();

        void CreateIngredient(Ingredient ingredient);

    }
}
