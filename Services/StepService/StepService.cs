using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookyAPI.Model.Entities.FoodEntity;

namespace CookyAPI.Services.StepService
{
    public class StepService : IStepService
    {
        DataContext _context;
        public StepService(DataContext context)
        {
            _context = context;
        }
        public void AddStep(Step step)
        {
            var food = _context.Foods.Where(f=>f.Id == step.Food.Id).SingleOrDefault();
            _context.Steps.Add(step);
            food.Step.Add(step);
            _context.SaveChanges();
        }

        public void DelAllStepOfFood(int foodID)
        {
            var food = _context.Foods.Where(s=>s.Id==foodID).SingleOrDefault();
            var foodSteps = _context.Steps.Where(s=>s.Food.Id==foodID).ToList();
            foreach (var item in foodSteps)
            {
                food.Step.Remove(item);
                _context.Steps.Remove(item);
            }
            _context.SaveChanges();
        }

   

        public void DelStepById(int foodID, int id)
        {
            var food = _context.Foods.Where(s=>s.Id==foodID).SingleOrDefault();
            var foodSteps = _context.Steps.Where(s=>s.Food.Id==foodID).Where(s=>s.Id==id).SingleOrDefault();
            if(food!=null && foodSteps!=null)
            {
                food.Step.Remove(foodSteps);
                _context.Steps.Remove(foodSteps);
            }
            _context.SaveChanges();
        }

        public List<Step> GetStepInFood(int foodID)
        { 
            var listStep = _context.Steps.Where(s=>s.Food.Id==foodID).Select(s=>new Step{
                Id = s.Id,
                Content = s.Content
              }).ToList();
            return listStep;
        }

        public Step GetStepInFoodById(int foodID, int id)
        { 
            var step = _context.Steps.Where(s=>s.Food.Id==foodID).Select(s=>new Step{
                Id = s.Id,
                Content = s.Content
              }).Where(s=>s.Id==id).SingleOrDefault();
              return step;
        }

        public void UpdateStep(Step step)
        {
            var oldStep = _context.Steps.Where(s=>s.Food.Id == step.Food.Id).Where(s=>s.Id == step.Id).SingleOrDefault();
            oldStep.Content = step.Content;
            oldStep.No = step.No;
            oldStep.Image = step.Image;
            _context.SaveChanges();
        }
    }
}