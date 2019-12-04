﻿// <auto-generated />
using System;
using CookyAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CookyAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CookyAPI.Model.Entities.FoodEntity.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CookTime");

                    b.Property<string>("FoodName");

                    b.Property<int?>("GerneID");

                    b.Property<string>("Material");

                    b.Property<string>("PrepareTime");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("GerneID");

                    b.HasIndex("UserId");

                    b.ToTable("Food");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FoodName = "Canh cai nau tom",
                            Material = "Cai ngot, Tom",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            FoodName = "Ga chien mam",
                            Material = "Ga",
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            FoodName = "Tom rang",
                            Material = "Tom",
                            UserId = 5
                        },
                        new
                        {
                            Id = 4,
                            FoodName = "Canh chua ca loc",
                            Material = "Do chua, ca",
                            UserId = 6
                        });
                });

            modelBuilder.Entity("CookyAPI.Model.Entities.FoodEntity.Gerne", b =>
                {
                    b.Property<int>("GerneID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GerneName");

                    b.HasKey("GerneID");

                    b.ToTable("Gerne");

                    b.HasData(
                        new
                        {
                            GerneID = 1,
                            GerneName = "Bua sang"
                        });
                });

            modelBuilder.Entity("CookyAPI.Model.Entities.FoodEntity.Step", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content");

                    b.Property<int?>("FoodId");

                    b.Property<string>("Image");

                    b.Property<int>("No");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.ToTable("Step");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Rua sach rau, sau do cat nho thanh mot doan bang 2cm.",
                            FoodId = 1,
                            No = 1
                        },
                        new
                        {
                            Id = 2,
                            Content = "Rua sach tom, lot vo, bam nho tom",
                            FoodId = 1,
                            No = 2
                        });
                });

            modelBuilder.Entity("CookyAPI.Model.Entities.UserEntity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Avatar");

                    b.Property<string>("EMail");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<int>("Role");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EMail = "chang@gmail.com",
                            Name = "Chang",
                            Password = "cooky",
                            Role = 1
                        },
                        new
                        {
                            Id = 2,
                            EMail = "chu@gmail.com",
                            Name = "Chu",
                            Password = "cooky",
                            Role = 0
                        },
                        new
                        {
                            Id = 3,
                            EMail = "cao@gmail.com",
                            Name = "Cao",
                            Password = "cooky",
                            Role = 0
                        },
                        new
                        {
                            Id = 4,
                            EMail = "cuc@gmail.com",
                            Name = "Cuc",
                            Password = "cooky",
                            Role = 0
                        },
                        new
                        {
                            Id = 5,
                            EMail = "kabi@gmail.com",
                            Name = "Kabi",
                            Password = "cooky",
                            Role = 0
                        },
                        new
                        {
                            Id = 6,
                            EMail = "ponkgmail.com",
                            Name = "Ponk",
                            Password = "cooky",
                            Role = 0
                        },
                        new
                        {
                            Id = 7,
                            EMail = "khoabe@gmail.com",
                            Name = "Khoa Be",
                            Password = "cooky",
                            Role = 0
                        },
                        new
                        {
                            Id = 8,
                            EMail = "na@gmail.com",
                            Name = "Na",
                            Password = "cooky",
                            Role = 0
                        },
                        new
                        {
                            Id = 9,
                            EMail = "chi@gmail.com",
                            Name = "Chi",
                            Password = "cooky",
                            Role = 0
                        },
                        new
                        {
                            Id = 10,
                            EMail = "zayn@gmail.com",
                            Name = "Zayn",
                            Password = "cooky",
                            Role = 0
                        },
                        new
                        {
                            Id = 11,
                            EMail = "kem@gmail.com",
                            Name = "Kem",
                            Password = "cooky",
                            Role = 0
                        });
                });

            modelBuilder.Entity("CookyAPI.Model.Entities.FoodEntity.Food", b =>
                {
                    b.HasOne("CookyAPI.Model.Entities.FoodEntity.Gerne", "Gerne")
                        .WithMany("Food")
                        .HasForeignKey("GerneID");

                    b.HasOne("CookyAPI.Model.Entities.UserEntity.User", "User")
                        .WithMany("Food")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CookyAPI.Model.Entities.FoodEntity.Step", b =>
                {
                    b.HasOne("CookyAPI.Model.Entities.FoodEntity.Food", "Food")
                        .WithMany("Step")
                        .HasForeignKey("FoodId");
                });
#pragma warning restore 612, 618
        }
    }
}
