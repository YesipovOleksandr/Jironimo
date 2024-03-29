﻿// <auto-generated />
using System;
using Jironimo.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Jironimo.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230222154812_add_default_category")]
    partial class add_default_category
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Jironimo.DAL.Entities.Application", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("AppStoreLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GooglePlayLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Outsource")
                        .HasColumnType("bit");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("Jironimo.DAL.Entities.ApplicationDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("ApplicationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePathTwo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PositionImage")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.ToTable("ApplicationDetails");
                });

            modelBuilder.Entity("Jironimo.DAL.Entities.ApplicationDeveloper", b =>
                {
                    b.Property<Guid>("ApplicationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DeveloperId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ApplicationId", "DeveloperId");

                    b.HasIndex("DeveloperId");

                    b.ToTable("ApplicationDeveloper");
                });

            modelBuilder.Entity("Jironimo.DAL.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = new Guid("37f8a2a5-2db6-4f78-af65-b52fd41fa11e"),
                            Name = "Mobile"
                        },
                        new
                        {
                            Id = new Guid("d4e968f5-7a79-4870-bf22-48771fec1d7c"),
                            Name = "Web"
                        });
                });

            modelBuilder.Entity("Jironimo.DAL.Entities.Developer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Developers");
                });

            modelBuilder.Entity("Jironimo.DAL.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("85d38113-dfa8-4f42-a6da-829a7e0fadd6"),
                            Login = "admin",
                            Password = "Frostiq1"
                        });
                });

            modelBuilder.Entity("Jironimo.DAL.Entities.Application", b =>
                {
                    b.HasOne("Jironimo.DAL.Entities.Category", "Category")
                        .WithMany("Applications")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Jironimo.DAL.Entities.ApplicationDetails", b =>
                {
                    b.HasOne("Jironimo.DAL.Entities.Application", "Application")
                        .WithMany("ApplicationDetails")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");
                });

            modelBuilder.Entity("Jironimo.DAL.Entities.ApplicationDeveloper", b =>
                {
                    b.HasOne("Jironimo.DAL.Entities.Application", "Application")
                        .WithMany("ApplicationDeveloper")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Jironimo.DAL.Entities.Developer", "Developer")
                        .WithMany("ApplicationDeveloper")
                        .HasForeignKey("DeveloperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");

                    b.Navigation("Developer");
                });

            modelBuilder.Entity("Jironimo.DAL.Entities.Application", b =>
                {
                    b.Navigation("ApplicationDetails");

                    b.Navigation("ApplicationDeveloper");
                });

            modelBuilder.Entity("Jironimo.DAL.Entities.Category", b =>
                {
                    b.Navigation("Applications");
                });

            modelBuilder.Entity("Jironimo.DAL.Entities.Developer", b =>
                {
                    b.Navigation("ApplicationDeveloper");
                });
#pragma warning restore 612, 618
        }
    }
}
