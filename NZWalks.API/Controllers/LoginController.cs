using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using NZWalks.API.Models;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public ActionResult Login(LoginDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please Provide Username and Password");
            }

            LoginResponseDto response = new() { Username = model.Username};

            if(model.Username == "Vivek" && model.Password == "Vivek123")
            {
                var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("JWTSecretKey"));
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Issuer = _configuration.GetValue<string>("LocalIssuer"),
                    Audience = _configuration.GetValue<string>("LocalAudience"),

                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        //Username
                        new Claim(ClaimTypes.Name, model.Username),
                        //Role
                        new Claim(ClaimTypes.Role, "Admin")
                    }),
                    Expires = DateTime.Now.AddHours(4),
                    SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                response.Token = tokenHandler.WriteToken(token);
            }
            else
            {
                return Ok("Invalid username and password");
            }

            return Ok(response);
        }
    }
}
