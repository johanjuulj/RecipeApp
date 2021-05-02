﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public interface IIngredientRepo
    {
        IEnumerable<Recipe> GetAllIngredients { get; }

        //IEnumerable<Recipe> SearchRecipes { get; }
        Recipe GetIngredientById(int ingredientId);

    }
}