using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        

        public CategoryDSK Category { get; set; }
        
        [Column(TypeName = "decimal(18,4)")]
        public decimal TotalKgCo2eq { get; set; }


        //data annotation http://jameschambers.com/2019/06/No-Type-Was-Specified-for-the-Decimal-Column/
        [Column(TypeName = "decimal(18,4)")]
        public decimal Caloriesperkg { get; set; }

        public IList<RecipeIngredient> RecipeIngredients { get; set; } 

        public Ingredient()
        {

        }
        public Ingredient(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
        public Ingredient(int Id, string Name, decimal TotalKgCo2eq, decimal Caloriesperkg)
        {
            this.Id = Id;
            this.Name = Name;
            this.TotalKgCo2eq = TotalKgCo2eq;
            this.Caloriesperkg = Caloriesperkg;
        }
    }
}
