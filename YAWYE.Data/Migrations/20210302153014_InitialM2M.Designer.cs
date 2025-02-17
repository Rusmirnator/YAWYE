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
    [Migration("20210302153014_InitialM2M")]
    partial class InitialM2M
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("YAWYE.Core.CalcData", b =>
                {
                    b.Property<int>("CalcDataId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("IngredientWeight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("MealId")
                        .HasColumnType("int");

                    b.Property<int>("MealIndex")
                        .HasColumnType("int");

                    b.Property<int>("ProductIndex")
                        .HasColumnType("int");

                    b.HasKey("CalcDataId");

                    b.HasIndex("MealId");

                    b.ToTable("CalcDatas");
                });

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

                    b.Property<decimal>("ProductWeight")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("MealId", "ProductId");

                    b.HasIndex("ProductId");

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

            modelBuilder.Entity("YAWYE.Core.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(16)")
                        .HasMaxLength(16);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("YAWYE.Core.CalcData", b =>
                {
                    b.HasOne("YAWYE.Core.Meal", null)
                        .WithMany("CalcDatas")
                        .HasForeignKey("MealId");
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
