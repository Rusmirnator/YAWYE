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
        public DbSet<User> Users { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<CalcData> CalcDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meal>()
            .HasMany(m => m.Products)
            .WithOne();

            modelBuilder.Entity<Meal>()
                .HasMany(m => m.Stats)
                .WithOne();


            modelBuilder.Entity<Day>()
                .HasMany(b => b.MyMeals)
                .WithOne();

        }

    }
}
