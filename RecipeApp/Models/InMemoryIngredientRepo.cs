//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace RecipeApp.Models
//{
//    public class InMemoryIngredientRepo : IIngredientRepo
//    {

//        public IEnumerable<Ingredient> AllIngredients =>
//          new List<Ingredient>
//          {

//                new Ingredient { Id = 1, Name ="Minced Meat" , Caloriesperkg = 125 , TotalKgCo2eq = 20},
//                new Ingredient { Id = 2, Name ="Parmagianno" , Caloriesperkg = 85 , TotalKgCo2eq = 10},
//                new Ingredient { Id = 3, Name ="Spaghetti" , Caloriesperkg = 30 , TotalKgCo2eq = 4},
//                new Ingredient { Id = 4, Name ="Tomato",  Caloriesperkg = 15 , TotalKgCo2eq = 10}
//          };
//        public IEnumerable<Ingredient> GetAllIngredients => throw new NotImplementedException();

//        public Ingredient GetIngredientById(int ingredientId)
//        {
//            throw new NotImplementedException();
//        }

//        IEnumerable<Ingredient> IIngredientRepo.AllIngredients()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
