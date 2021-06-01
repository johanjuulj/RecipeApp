using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.ViewModels
{
    public class FoodPlanViewModel
    {
        public FoodPlan FoodPlan { get; set; }
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public decimal ShoppingCartTotal { get; set; }
    }
}
