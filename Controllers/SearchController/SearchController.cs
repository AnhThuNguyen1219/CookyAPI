using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookyAPI.Model.Entities.FoodEntity;
using CookyAPI.Services.FoodService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CookyAPI.Controllers.SearchController
{
    [Route("api/[controller]/{search}")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class SearchController : ControllerBase
    {
        private IFoodService _ifs;
        public SearchController(IFoodService ifs)
        {
            _ifs = ifs;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Food>> Get(string search)
        {
            return _ifs.GetFoodByName(search);
        }

       
    }
}