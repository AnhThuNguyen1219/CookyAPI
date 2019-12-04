using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookyAPI.Model.Entities.FoodEntity;
using CookyAPI.Services.StepService;
using Microsoft.AspNetCore.Mvc;

namespace CookyAPI.Controllers.StepController
{
    [Route("api/food/{foodID}/[controller]")]
    [ApiController]
    public class StepController : ControllerBase
    {
        IStepService _iss;
        public StepController(IStepService iss)
        {
            _iss = iss;
        }
        [HttpGet()]
        public ActionResult<IEnumerable<Step>> Get(int foodId)
        {
            return _iss.GetStepInFood(foodId);
        }

        [HttpGet("{id}")]
       
        public ActionResult<Step> Get(int foodId, int id)
        {
            return _iss.GetStepInFoodById(foodId, id);
        }

        [HttpPost]
        public void Post([FromBody] Step step)
        {
            _iss.AddStep(step);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Step step)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}