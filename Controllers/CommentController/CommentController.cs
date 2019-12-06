using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookyAPI.Model.Entities.FoodEntity;
using CookyAPI.Services.CommentService;
using Microsoft.AspNetCore.Mvc;

namespace CookyAPI.Controllers.CommentController
{
    [Route("api/food/{FoodId}/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        ICommentService _ics;
        public CommentController(ICommentService ics)
        {
            _ics = ics;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Comment>> Get(int FoodId)
        {
            return _ics.GetComments(FoodId);
        }

        // [HttpGet("{id}")]
        // public ActionResult<string> Get(int id)
        // {
        //     return "value";
        // }

        [HttpPost]
        public void Post([FromBody] Comment com)
        {
            _ics.AddComment(com);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Comment com)
        {
            _ics.UpdateComment(id, com);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _ics.DelComment(id);
        }
    }
}