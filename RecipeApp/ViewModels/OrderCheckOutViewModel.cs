﻿using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.ViewModels
{
    public class OrderCheckOutViewModel
    {
        public  Order Order  { get; set; }

        public List<FoodPlanRecipe> RecipeList { get; set; }
    }
}
