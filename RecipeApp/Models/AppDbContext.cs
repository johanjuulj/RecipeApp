using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecipeApp.csvReader;
using System;
using System.Collections.Generic;
using System.IO;
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

          

            modelBuilder.Entity<Recipe>().HasData(new Recipe
            {
                Id = 1,
                Name = "Bolognese",
                
                ShortDescription = "Best authentic bolognese recipe in the world",
               
                ImageUrl = "https://gdurl.com/ECJD",
                Kitchen = Cuisine.Italian
                
            });

            modelBuilder.Entity<Recipe>().HasData(new Recipe
            {
                Id = 2,
                Name = "Cabonara",
                
                ShortDescription = "You'll love it!",
                
                ImageUrl = "https://gdurl.com/oIcC",
                Kitchen = Cuisine.American

            });

            modelBuilder.Entity<Recipe>().HasData(new Recipe
            {
                Id = 3,
                Name = "Steg Flæsk med Persillesovs",
               
                ShortDescription = "The best of the worst danish cuisine can bring you",
                
                ImageUrl = "http://gdurl.com/4QHf",
                Kitchen = Cuisine.Danish
            });

            modelBuilder.Entity<Recipe>().HasData(new Recipe
            {
                Id = 4,
                Name = "Burrito",
                
                ShortDescription = "A summer classic!",
                
                ImageUrl = "https://gdurl.com/r6sb/",
                Kitchen = Cuisine.Mexican
            });

            modelBuilder.Entity<Recipe>().HasData(new Recipe
            {
                Id = 5,
                Name = "Roll Egg",
               
                ShortDescription = "Almost as good as a Rolex",
                
                ImageUrl = "https://gdurl.com/ydzp/",
                Kitchen = Cuisine.Ugandan
            });

            modelBuilder.Entity<Recipe>().HasData(new Recipe
            {
                Id = 6,
                Name = "Hamburger",
                
                ShortDescription = "As American as they come",
                
                ImageUrl = "https://gdurl.com/MCEv",
                Kitchen = Cuisine.American
            });



        }
    }
}
