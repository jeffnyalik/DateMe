using Microsoft.Win32.SafeHandles;
using System.Text;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingAPI.Dtos;
using DatingAPI.Interface;
using DatingAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace DatingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthsController : ControllerBase
    {   
        private readonly IAuthRepository authRepo;
        private readonly IConfiguration _configuration;
        public AuthsController(IAuthRepository authRepo, IConfiguration configuration)
        {
            this.authRepo = authRepo;
            _configuration = configuration;
        }

        [HttpPost("user-register")]
        public async Task<IActionResult> UserRegister([FromBody] UserRegisterDto userRegisterDto)
        {   
           
            userRegisterDto.UserName = userRegisterDto.UserName.ToLower();
            userRegisterDto.Email = userRegisterDto.Email.ToLower();
            if(await authRepo.UserExists(userRegisterDto.UserName))
            {
                return BadRequest("Username already exist");
            }
            if(await authRepo.EmailExists(userRegisterDto.Email))
            {
                return BadRequest("Email already exist");
            }
            var user = new User
            {
                UserName = userRegisterDto.UserName,
                Email = userRegisterDto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(userRegisterDto.Password)
            };
            
            var res  = authRepo.Create(user);
            return Ok(new {
                message = res.Email, res.UserName
            });
        }

        [HttpPost("user-login")]
        public IActionResult UserLogin([FromBody]FromUserLoginDto fromUserLoginDto)
        {
            var user = authRepo.GetByEmail(fromUserLoginDto.Email.ToLower());
            if(user == null) return BadRequest(new {message = "Invalid credentials"});
            if(!BCrypt.Net.BCrypt.Verify(fromUserLoginDto.Password, user.Password))
            {
                return BadRequest(new {message = "Invalid credentials"});
            }
            
            var res = GenerateUserJwtToken(user);
            return Ok(new { token = res} );
            
        }


        private string GenerateUserJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Secret").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()), 
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.UserName)
                 }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

      
    }
}