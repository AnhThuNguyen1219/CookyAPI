using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CookyAPI.Model.Entities.FoodEntity;
using CookyAPI.Services.FoodService;
using Microsoft.AspNetCore.Authorization;

namespace CookyAPI.Controllers.FoodController
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FoodController : ControllerBase
    {
        private IFoodService _ifs;
        public FoodController(IFoodService ifs)
        {
            _ifs = ifs;
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<Food>> Get()
        {
            return _ifs.GetFoods();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<Food> Get(int id)
        {
            return _ifs.GetFoodById(id);
        }

        [HttpPost]
        public void Post([FromBody] Food food)
        {
            _ifs.AddFood(food);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]  Food food)
        {
            _ifs.UpdateFood(id, food);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _ifs.DelFood(id);
        }
        
        
    }
}