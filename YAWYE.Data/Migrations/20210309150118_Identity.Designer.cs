﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YAWYE.Data;

namespace YAWYE.Data.Migrations
{
    [DbContext(typeof(YAWYEDbContext))]
    [Migration("20210309150118_Identity")]
    partial class Identity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("YAWYE.Core.Day", b =>
                {
                    b.Property<int>("DayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("TodayIs")
                        .HasColumnType("int");

                    b.HasKey("DayId");

                    b.ToTable("Days");
                });

            modelBuilder.Entity("YAWYE.Core.Meal", b =>
                {
                    b.Property<int>("MealId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Carbohydrates")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("DayId")
                        .HasColumnType("int");

                    b.Property<decimal>("Fat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Fiber")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ImgPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Kcal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("MealId1")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Protein")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("MealId");

                    b.HasIndex("DayId");

                    b.HasIndex("MealId1");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("YAWYE.Core.MealProduct", b =>
                {
                    b.Property<int>("MealId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("MealProductMealId")
                        .HasColumnType("int");

                    b.Property<int?>("MealProductProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("ProductWeight")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("MealId", "ProductId");

                    b.HasIndex("ProductId");

                    b.HasIndex("MealProductMealId", "MealProductProductId");

                    b.ToTable("MealProducts");
                });

            modelBuilder.Entity("YAWYE.Core.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BarCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Carbohydrates")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Fat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Fiber")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("HasImage")
                        .HasColumnType("bit");

                    b.Property<string>("ImgPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Kcal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<int?>("MealId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Protein")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalWeight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductId");

                    b.HasIndex("MealId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("YAWYE.Core.Meal", b =>
                {
                    b.HasOne("YAWYE.Core.Day", null)
                        .WithMany("Meals")
                        .HasForeignKey("DayId");

                    b.HasOne("YAWYE.Core.Meal", null)
                        .WithMany("Meals")
                        .HasForeignKey("MealId1");
                });

            modelBuilder.Entity("YAWYE.Core.MealProduct", b =>
                {
                    b.HasOne("YAWYE.Core.Meal", "Meal")
                        .WithMany("MealProducts")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YAWYE.Core.Product", "Product")
                        .WithMany("MealProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YAWYE.Core.MealProduct", null)
                        .WithMany("MealProducts")
                        .HasForeignKey("MealProductMealId", "MealProductProductId");
                });

            modelBuilder.Entity("YAWYE.Core.Product", b =>
                {
                    b.HasOne("YAWYE.Core.Meal", null)
                        .WithMany("Products")
                        .HasForeignKey("MealId");
                });
#pragma warning restore 612, 618
        }
    }
}
