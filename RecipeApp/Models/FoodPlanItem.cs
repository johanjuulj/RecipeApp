using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class FoodPlanItem
    {
        public int Id { get; set; }

        public Recipe Recipe { get; set; }

        public int CO2 { get; set; }

        public int Amount { get; set; }

        public string FoodPlanId { get; set; }

    }
}
