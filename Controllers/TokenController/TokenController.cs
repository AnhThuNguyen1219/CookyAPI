using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CookyAPI.Controllers.TokenController
{
    public class TokenController : ControllerBase
    {
        private const string SECRET_KEY = "abcgyb126hunjdef";
        public static readonly SymmetricSecurityKey SIGHING_KEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));

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

        [HttpGet]
        [Route("api/login/{Name}/{Password}")]
        public IActionResult Get(string Name, string Password)
        {
            if(Password.Equals("cooky")) return new ObjectResult(GenerateToken(Name));
            else return BadRequest();
        }
    }
}