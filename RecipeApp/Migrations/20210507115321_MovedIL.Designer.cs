// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecipeApp.Models;

namespace RecipeApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210507115321_MovedIL")]
    partial class MovedIL
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RecipeApp.Models.FoodPlanRecipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("FoodPlanId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("FoodPlanItems");
                });

            modelBuilder.Entity("RecipeApp.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("CO2Per100G")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("CaloriesPer100G")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShelfLifeDays")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CO2Per100G = 20m,
                            CaloriesPer100G = 125m,
                            Name = "Minced Meat",
                            ShelfLifeDays = 7
                        },
                        new
                        {
                            Id = 2,
                            CO2Per100G = 10m,
                            CaloriesPer100G = 85m,
                            Name = "Parmagiano",
                            ShelfLifeDays = 50
                        },
                        new
                        {
                            Id = 3,
                            CO2Per100G = 4m,
                            CaloriesPer100G = 30m,
                            Name = "Spaghetti",
                            ShelfLifeDays = 400
                        },
                        new
                        {
                            Id = 4,
                            CO2Per100G = 10m,
                            CaloriesPer100G = 15m,
                            Name = "Tomato",
                            ShelfLifeDays = 12
                        });
                });

            modelBuilder.Entity("RecipeApp.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Kitchen")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Recipes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fopskrifter.coop.dk%2Fopskrifter%2Fspaghetti-bolognese-760&psig=AOvVaw1Idfy2G91X7H3FP8kX0WSg&ust=1620205352346000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCPCa1rbVr_ACFQAAAAAdAAAAABAF",
                            Kitchen = 2,
                            Name = "Bolognese",
                            Price = 0m,
                            ShortDescription = "Best authentic bolognese recipe in the world"
                        },
                        new
                        {
                            Id = 2,
                            ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/blueberrycheesecake.jpg",
                            Kitchen = 6,
                            Name = "Blueberry Cheese Cake",
                            Price = 0m,
                            ShortDescription = "You'll love it!"
                        },
                        new
                        {
                            Id = 3,
                            ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cheesecake.jpg",
                            Kitchen = 1,
                            Name = "Steg Flæsk med Persillesovs",
                            Price = 0m,
                            ShortDescription = "The best of the worst danish cuisine can bring you"
                        },
                        new
                        {
                            Id = 4,
                            ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cherrypie.jpg",
                            Kitchen = 6,
                            Name = "Cherry Pie",
                            Price = 0m,
                            ShortDescription = "A summer classic!"
                        },
                        new
                        {
                            Id = 5,
                            ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/christmasapplepie.jpg",
                            Kitchen = 6,
                            Name = "Christmas Apple Pie",
                            Price = 0m,
                            ShortDescription = "Happy holidays with this pie!"
                        },
                        new
                        {
                            Id = 6,
                            ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cranberrypie.jpg",
                            Kitchen = 6,
                            Name = "Cranberry Pie",
                            Price = 0m,
                            ShortDescription = "A Christmas favorite"
                        },
                        new
                        {
                            Id = 7,
                            ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/peachpie.jpg",
                            Kitchen = 6,
                            Name = "Peach Pie",
                            Price = 0m,
                            ShortDescription = "Sweet as peach"
                        },
                        new
                        {
                            Id = 8,
                            ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/pumpkinpie.jpg",
                            Kitchen = 6,
                            Name = "Pumpkin Pie",
                            Price = 0m,
                            ShortDescription = "Our Halloween favorite"
                        });
                });

            modelBuilder.Entity("RecipeApp.Models.FoodPlanRecipe", b =>
                {
                    b.HasOne("RecipeApp.Models.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId");
                });
#pragma warning restore 612, 618
        }
    }
}
