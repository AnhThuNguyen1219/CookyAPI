using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookyAPI.Model.Entities.FoodEntity;
using CookyAPI.Model.Entities.UserEntity;

namespace CookyAPI.Services.FoodService
{
    public class FoodService : IFoodService
    {
        DataContext _context;
        public FoodService(DataContext context)
        {
            _context = context;
        }

        public void DelFood(int id)
        {
            var food = new Food();
            food = _context.Foods.Where(f=>f.Id==id).SingleOrDefault();
            // var user = _context.Users.Where(u=>u.Id==food.User.Id).SingleOrDefault();
            // user.Food.Remove(food);
            _context.Foods.Remove(food);
            _context.SaveChanges();
        }

        public Food GetFoodById(int id)//get tat ca thong tin cua 1 mon an
        {
            var food = new Food();
            food = _context.Foods.Where(f=>f.Id==id).Select(f=> new Food
            {
                Id = f.Id,
                FoodName = f.FoodName,
                Material= f.Material,
                User = new User{
                  // Id = f.User.Id,
                   Name = f.User.Name,
                  // User = f.User
               },
               Gerne = new Gerne
               {
               // GerneID = f.Gerne.GerneID,
                GerneName = f.Gerne.GerneName
               }
               ,
               Step = f.Step.Select(s=> new Step{
                   Id = s.Id,
                   Content = s.Content
               }).ToList()
            }).SingleOrDefault();
            return food;
        }

        public List<Food> GetFoods()//get tat ca cac mon, nen k get user + step
        {
            var food =  _context.Foods.OrderBy(f=>f.Id).Select(f => new Food
           {
               Id = f.Id,
               FoodName = f.FoodName,
               Material = f.Material,
               User = new User {Name = f.User.Name},
               Gerne = new Gerne
               {
               // GerneID = f.Gerne.GerneID,
                GerneName = f.Gerne.GerneName
               }
            })
           .ToList();
            
            return food;
        }

        public void UpdateFood(int id, Food food)//update mon an, 
        //con update cac buoc se thuc hien o cho cac buoc
        {
            var notUpdateYet = new Food();
            notUpdateYet = _context.Foods.Where(f=>f.Id==id).SingleOrDefault();
            notUpdateYet.FoodName = food.FoodName;      
            notUpdateYet.User.Id = food.User.Id;
            _context.SaveChanges();
        }
        public void AddFood(Food food)//add mon an, 
        //add buoc se thuc hien o cac buoc sau
        {
            var user = new User();
            user =  _context.Users.FirstOrDefault(x=>x.Id == food.User.Id);
            
            _context.Foods.Add(food);
            user.Food.Add(food);
            
            _context.SaveChanges();
        }
    }
}