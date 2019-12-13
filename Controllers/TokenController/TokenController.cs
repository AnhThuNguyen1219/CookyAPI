using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CookyAPI.Model.Entities.UserEntity;
using CookyAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CookyAPI.Controllers.TokenController
{
    public class TokenController : ControllerBase
    {
        private const string SECRET_KEY = "abcgyb126hunjdef";
        public static readonly SymmetricSecurityKey SIGHING_KEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));

        private IUsersService _ius ;
        public TokenController(IUsersService ius)
        {
            _ius = ius;
        }
        private string GenerateToken (string username)
        { 
            var token = new JwtSecurityToken(
                claims:new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                },
                notBefore:new DateTimeOffset(DateTime.Now).DateTime,
                expires:new DateTimeOffset(DateTime.Now.AddMinutes(60)).DateTime,
                signingCredentials:new SigningCredentials(SIGHING_KEY,SecurityAlgorithms.HmacSha256)
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost]
        [Route("api/login/")]
        public IActionResult Login([FromBody]Login user)
        {
            var users = _ius.GetLogin(user);
            if(users!=null) return new ObjectResult(GenerateToken(user.Name));
            else return BadRequest();
        }
        
    }
}