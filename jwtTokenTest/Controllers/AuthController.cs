using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace jwtTokenTest.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {


        [Route("GetUser")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IEnumerable<string> Index()
        {
            string[] abc = new string[3];
            abc[0] = "abc";
            abc[1] = "bcd";
            return abc;
        }

        [HttpPost("token")]

        public IActionResult Token()
        {
            var header = Request.Headers["Authorization"];
            if (header.ToString().StartsWith("Basic"))
            {
                var credValue = header.ToString().Substring("basic".Length).Trim();
                var userCredential = Encoding.UTF8.GetString(Convert.FromBase64String(credValue));
                var userNamePass = userCredential.Split(':');
                if (userNamePass[0] == "jai" && userNamePass[1] == "jai")
                {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("yourKeyyourKeyyourKeyyourKeyyourKeyyourK"));
                    var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var userClaim = new[]
                    {
                new Claim(ClaimTypes.Name,"ashutosh")
              };
                    var token = new JwtSecurityToken(
                        issuer: "localhost:44304",
                        audience: "localhost:44304",
                        expires: DateTime.Now.AddMinutes(10),
                        claims: userClaim,
                        signingCredentials: credential
                        );

                    string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                    return Ok(tokenString);
                }
            }
            return BadRequest("usrname not found");
          
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
