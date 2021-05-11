using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public interface IFoodPlanRepo
    {

        void CreatePlan(FoodPlan Plan);
    }
}
