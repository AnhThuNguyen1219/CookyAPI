using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookyAPI.Model.Entities.FoodEntity;

namespace CookyAPI.Services.FoodService
{
    public interface IFoodService
    {
        List<Food> GetFoods();
        Food GetFoodById(int id);
        void DelFood(int id);
        void UpdateFood(int id,Food food);
        void AddFood(Food food);
        List<Food> GetFoodByName(string Name);

    }
}