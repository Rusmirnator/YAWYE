using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using YAWYE.Core;

namespace YAWYE.Data
{
    public class YAWYEDbContext : DbContext
    {
        public YAWYEDbContext(DbContextOptions<YAWYEDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<MealProduct> MealProducts { get; set; }
        public DbSet<DayMeal> DayMeals { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MealProduct>()
                .HasKey(mp => new { mp.MealId, mp.ProductId });

            builder.Entity<MealProduct>()
                .HasOne(mp => mp.Meal)
                .WithMany(m => m.MealProducts)
                .HasForeignKey(mp => mp.MealId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Meal>()
                .HasMany(m => m.MealProducts)
                .WithOne(mp => mp.Meal)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<MealProduct>()
                .HasOne(mp => mp.Product)
                .WithMany(p => p.MealProducts)
                .HasForeignKey(mp => mp.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Product>()
                .HasMany(p => p.MealProducts)
                .WithOne(mp => mp.Product)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<DayMeal>()
                .HasKey(dm => new { dm.DayMealId });

            builder.Entity<DayMeal>()
                .HasOne(dm => dm.Day)
                .WithMany(d => d.DayMeals)
                .HasForeignKey(mp => mp.DayId);

            builder.Entity<DayMeal>()
                .HasOne(dm => dm.Meal)
                .WithMany(m => m.DayMeals)
                .HasForeignKey(dm => dm.MealId);
        }

    }
}
