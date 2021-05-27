using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class Ingredient
    {
        public int Id { get;  set; }
        public string Name { get; set; }
        public int ShelfLifeDays { get; set; }

        //data annotation http://jameschambers.com/2019/06/No-Type-Was-Specified-for-the-Decimal-Column/
        [Column(TypeName = "decimal(18,4)")]
        public decimal CaloriesPer100G { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal CO2Per100G { get; set; }

        public IList<RecipeIngredient> RecipeIngredients { get; set; } //non instantiated?

        public Ingredient()
        {

        }
        public Ingredient(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
        public Ingredient(int Id, string Name, int ShelfLifeDays, decimal CO2Per100G, decimal CaloriesPer100G)
        {
            this.Id = Id;
            this.Name = Name;
            this.ShelfLifeDays = ShelfLifeDays;
            this.CO2Per100G = CO2Per100G;
            this.CaloriesPer100G = CaloriesPer100G;
        }
    }
}
