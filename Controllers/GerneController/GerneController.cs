using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookyAPI.Model.Entities.FoodEntity;
using CookyAPI.Services.GerneService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CookyAPI.Controllers.GerneController
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class GerneController : ControllerBase
    {
        IGerneService _igs;
        public GerneController(IGerneService igs)
        {
            _igs=igs;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Gerne>> Get()
        {
            return _igs.GetGerne();
        }

        [HttpGet("{id}")]
        public ActionResult<Gerne> Get(int id)
        {
            return _igs.GetGerneById(id);
        }

        [HttpPost]
        public void Post([FromBody] Gerne ge)
        {
            _igs.AddGerne(ge);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Gerne ge)
        {
            _igs.UpdateGerne(id, ge);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _igs.DelGerne(id);
        }
    }
}