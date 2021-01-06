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

    }
}
