﻿// <auto-generated />
using System;
using DogReviewApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DogReviewApp.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DogReviewApp.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DogReviewApp.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("DogReviewApp.Models.Dog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Dog");
                });

            modelBuilder.Entity("DogReviewApp.Models.DogCategory", b =>
                {
                    b.Property<int>("DogId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("DogId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("DogCategories");
                });

            modelBuilder.Entity("DogReviewApp.Models.DogOwner", b =>
                {
                    b.Property<int>("DogId")
                        .HasColumnType("int");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.HasKey("DogId", "OwnerId");

                    b.HasIndex("OwnerId");

                    b.ToTable("DogOwner");
                });

            modelBuilder.Entity("DogReviewApp.Models.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Club")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("DogReviewApp.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DogId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DogId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("DogReviewApp.Models.Reviewer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Reviewers");
                });

            modelBuilder.Entity("ReviewReviewer", b =>
                {
                    b.Property<int>("ReviewerId")
                        .HasColumnType("int");

                    b.Property<int>("ReviewsId")
                        .HasColumnType("int");

                    b.HasKey("ReviewerId", "ReviewsId");

                    b.HasIndex("ReviewsId");

                    b.ToTable("ReviewReviewer");
                });

            modelBuilder.Entity("DogReviewApp.Models.DogCategory", b =>
                {
                    b.HasOne("DogReviewApp.Models.Category", "Category")
                        .WithMany("DogCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DogReviewApp.Models.Dog", "Dog")
                        .WithMany("DogCategories")
                        .HasForeignKey("DogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Dog");
                });

            modelBuilder.Entity("DogReviewApp.Models.DogOwner", b =>
                {
                    b.HasOne("DogReviewApp.Models.Dog", "Dog")
                        .WithMany("DogOwners")
                        .HasForeignKey("DogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DogReviewApp.Models.Owner", "Owner")
                        .WithMany("DogOwners")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dog");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("DogReviewApp.Models.Owner", b =>
                {
                    b.HasOne("DogReviewApp.Models.Country", "Country")
                        .WithMany("Owners")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("DogReviewApp.Models.Review", b =>
                {
                    b.HasOne("DogReviewApp.Models.Dog", "Dog")
                        .WithMany("Reviews")
                        .HasForeignKey("DogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dog");
                });

            modelBuilder.Entity("ReviewReviewer", b =>
                {
                    b.HasOne("DogReviewApp.Models.Reviewer", null)
                        .WithMany()
                        .HasForeignKey("ReviewerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DogReviewApp.Models.Review", null)
                        .WithMany()
                        .HasForeignKey("ReviewsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DogReviewApp.Models.Category", b =>
                {
                    b.Navigation("DogCategories");
                });

            modelBuilder.Entity("DogReviewApp.Models.Country", b =>
                {
                    b.Navigation("Owners");
                });

            modelBuilder.Entity("DogReviewApp.Models.Dog", b =>
                {
                    b.Navigation("DogCategories");

                    b.Navigation("DogOwners");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("DogReviewApp.Models.Owner", b =>
                {
                    b.Navigation("DogOwners");
                });
#pragma warning restore 612, 618
        }
    }
}
