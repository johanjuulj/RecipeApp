using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class RecipeIngredient
    {
        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }

        public int IngredientId { get; set; }

        public Ingredient Ingredient { get; set; }
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public decimal WeightofIngredient { get; set; }
    }
}
