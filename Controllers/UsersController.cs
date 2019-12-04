using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CookyAPI.Services;
using CookyAPI.Model.Entities.UserEntity;
using Microsoft.AspNetCore.Authorization;

namespace CookyAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersService _ius ;
        public UsersController(IUsersService ius)
        {
            _ius = ius;
        }
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return _ius.GetUsers();
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            return _ius.GetUserById(id);
        }

        [HttpPost]
        public void Post([FromBody] User user)
        {
            _ius.AddUser(user);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User user)
        {
            _ius.UpdateUser(id, user);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _ius.DelUser(id);
        }
    }
}