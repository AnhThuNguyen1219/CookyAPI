using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookyAPI.Model.Entities.FoodEntity;
using CookyAPI.Services.FoodService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CookyAPI.Controllers.FoodController
{
    [Route("api/food/gerne")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class FoodGerneController : ControllerBase
    {
        IFoodService _ifs;
        public FoodGerneController(IFoodService ifs)
        {
            _ifs = ifs;
        }
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return null;
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Food>> Get(int id)
        {
            return _ifs.GetFoodByGerne(id);
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}