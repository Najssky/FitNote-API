﻿// <auto-generated />
using System;
using FitNote_API.Data.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FitNote_API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FitNote_API.Data.Models.Exercise", b =>
                {
                    b.Property<Guid>("Exercise_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Exercise_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Exercise_id");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("FitNote_API.Data.Models.Training", b =>
                {
                    b.Property<Guid>("Training_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Training_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Training_details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Training_user_id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Training_id");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("FitNote_API.Data.Models.User", b =>
                {
                    b.Property<Guid>("User_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone_number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Token")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("User_id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
