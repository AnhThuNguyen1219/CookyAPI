using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CookyAPI.Model.Entities.UserEntity;
using CookyAPI.Model.Entities.FoodEntity;
//using System.Data.Entity;
namespace CookyAPI
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users {get; set;}
        public DbSet<Food> Foods {get; set;}
        public DbSet<Gerne> Gernes {get;set;}
        public DbSet<Step> Steps { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("User");
            builder.Entity<Food>().ToTable("Food");
            builder.Entity<Step>().ToTable("Step");
            builder.Entity<Gerne>().ToTable("Gerne");

            //relationship
            builder.Entity<User>().HasMany(f=>f.Food).WithOne(u=>u.User);
            builder.Entity<Food>().HasMany(s=>s.Step).WithOne(f=>f.Food);
            builder.Entity<Gerne>().HasMany(f=>f.Food).WithOne(g=>g.Gerne);
            base.OnModelCreating(builder);
            //seed  data
            builder.Entity<User>().HasData(
                new {Id =1,Name = "Chang", EMail="chang@gmail.com", Password = "cooky", Role=1},
                new {Id =2,Name = "Chu", EMail="chu@gmail.com", Password = "cooky", Role=0},
                new {Id =3,Name = "Cao", EMail="cao@gmail.com", Password = "cooky", Role=0},
                new {Id =4,Name = "Cuc", EMail="cuc@gmail.com", Password = "cooky", Role=0},
                new {Id =5,Name = "Kabi", EMail="kabi@gmail.com", Password = "cooky", Role=0},
                new {Id =6,Name = "Ponk", EMail="ponkgmail.com", Password = "cooky", Role=0},
                new {Id =7,Name = "Khoa Be", EMail="khoabe@gmail.com", Password = "cooky", Role=0},
                new {Id =8, Name = "Na", EMail="na@gmail.com", Password = "cooky", Role=0},
                new {Id =9,Name = "Chi", EMail="chi@gmail.com", Password = "cooky", Role=0},
                new {Id =10,Name = "Zayn", EMail="zayn@gmail.com", Password = "cooky", Role=0},
                new {Id =11,Name = "Kem", EMail="kem@gmail.com", Password = "cooky", Role=0}
                );

            builder.Entity<Gerne>().HasData(
                new {GerneID = 1, GerneName="Bua sang"}
            );

            builder.Entity<Food>().HasData(
                new {Id=1,FoodName= "Canh cai nau tom", Material="Cai ngot, Tom", UserId=1, GerneId=1},
                new {Id=2,FoodName= "Ga chien mam", Material="Ga", UserId=1,GerneId=1},
                new {Id=3,FoodName= "Tom rang", Material="Tom", UserId=5,GerneId=1},
                new {Id=4,FoodName= "Canh chua ca loc", Material="Do chua, ca", UserId=6,GerneId=1}
                );

            builder.Entity<Step>().HasData(
                new {Id=1, Content="Rua sach rau, sau do cat nho thanh mot doan bang 2cm.",FoodId=1, No=1},
                new {Id=2, Content="Rua sach tom, lot vo, bam nho tom",FoodId=1, No=2}
                );
            
             
        }
        
    }
}