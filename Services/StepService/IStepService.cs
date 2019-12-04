using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookyAPI.Model.Entities.FoodEntity;

namespace CookyAPI.Services.StepService
{
    public interface IStepService
    {
        void AddStep(Step step);
        void UpdateStep(Step step);
        List<Step> GetStepInFood(int foodID);
        Step GetStepInFoodById(int foodID, int id);
        void DelStepById(int foodID,int id);
        void DelAllStepOfFood(int foodID);

    }
}