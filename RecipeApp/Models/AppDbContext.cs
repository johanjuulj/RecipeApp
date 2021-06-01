using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<FoodPlanRecipe> FoodPlanItems { get; set; }

        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //sets foreign keys in RecipeIngredients
            modelBuilder.Entity<RecipeIngredient>().HasKey(c => new { c.IngredientId, c.RecipeId });

            base.OnModelCreating(modelBuilder);

            //seed categories
            modelBuilder.Entity<Ingredient>().HasData(new Ingredient { Id = 1, Name = "Minced Meat", ShelfLifeDays = 7, CaloriesPer100G = 125, CO2Per100G = 20 });
            modelBuilder.Entity<Ingredient>().HasData(new Ingredient { Id = 2, Name = "Parmagiano", ShelfLifeDays = 50, CaloriesPer100G = 85, CO2Per100G = 10 });
            modelBuilder.Entity<Ingredient>().HasData(new Ingredient { Id = 3, Name = "Spaghetti", ShelfLifeDays = 400, CaloriesPer100G = 30, CO2Per100G = 4 });
            modelBuilder.Entity<Ingredient>().HasData(new Ingredient { Id = 4, Name = "Tomato", ShelfLifeDays = 12, CaloriesPer100G = 15, CO2Per100G = 10 });
            //modelBuilder.Entity<Ingredient>().HasData(new Ingredient { Id = 5, Name = "Canned Tomato", ShelfLifeDays = 999, CaloriesPer100G = 19, CO2Per100G = 15 });

            //seed pies

            modelBuilder.Entity<Recipe>().HasData(new Recipe
            {
                Id = 1,
                Name = "Bolognese",
                
                ShortDescription = "Best authentic bolognese recipe in the world",
               
                ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fopskrifter.coop.dk%2Fopskrifter%2Fspaghetti-bolognese-760&psig=AOvVaw1Idfy2G91X7H3FP8kX0WSg&ust=1620205352346000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCPCa1rbVr_ACFQAAAAAdAAAAABAF",
                Kitchen = Cuisine.Italian
                
            });

            modelBuilder.Entity<Recipe>().HasData(new Recipe
            {
                Id = 2,
                Name = "Blueberry Cheese Cake",
                
                ShortDescription = "You'll love it!",
                
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/blueberrycheesecake.jpg",
                Kitchen = Cuisine.American

            });

            modelBuilder.Entity<Recipe>().HasData(new Recipe
            {
                Id = 3,
                Name = "Steg Flæsk med Persillesovs",
               
                ShortDescription = "The best of the worst danish cuisine can bring you",
                
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cheesecake.jpg",
                Kitchen = Cuisine.Danish
            });

            modelBuilder.Entity<Recipe>().HasData(new Recipe
            {
                Id = 4,
                Name = "Cherry Pie",
                
                ShortDescription = "A summer classic!",
                
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cherrypie.jpg",
                Kitchen = Cuisine.American
            });

            modelBuilder.Entity<Recipe>().HasData(new Recipe
            {
                Id = 5,
                Name = "Christmas Apple Pie",
               
                ShortDescription = "Happy holidays with this pie!",
                
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/christmasapplepie.jpg",
                Kitchen = Cuisine.American
            });

            modelBuilder.Entity<Recipe>().HasData(new Recipe
            {
                Id = 6,
                Name = "Cranberry Pie",
                
                ShortDescription = "A Christmas favorite",
                
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cranberrypie.jpg",
                Kitchen = Cuisine.American
            });

            modelBuilder.Entity<Recipe>().HasData(new Recipe
            {
                Id = 7,
                Name = "Peach Pie",
                
                ShortDescription = "Sweet as peach",
                
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/peachpie.jpg",
                Kitchen = Cuisine.American
            });

            modelBuilder.Entity<Recipe>().HasData(new Recipe
            {
                Id = 8,
                Name = "Pumpkin Pie",
                
                ShortDescription = "Our Halloween favorite",
                
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/pumpkinpie.jpg",
                Kitchen = Cuisine.American
            });


        }
    }
}
