using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EF.DAL.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using projet_WebApi_1.Dtos;
using projet_WebApi_1.Service;

namespace projet_WebApi_1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAutoRepository _autoRepository;

        public AuthController(IAutoRepository autoRepository)
        {
            _autoRepository = autoRepository;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserCreatDto user)
        {
            if (await _autoRepository.UserExist(user.Name))
            {
                return StatusCode(401);
            }
            User userCre = new User { Name = user.Name, PassWord = user.PassWord };
            await _autoRepository.Register(userCre);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserCreatDto user)
        {
            var _user = await _autoRepository.Login(user.Name, user.PassWord);
            if (_user != null)
            {

                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier,_user.ID.ToString()),
                    new Claim(ClaimTypes.Name,_user.Name)
                };
                var keye = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mohammed tqtqtqqt"));
                var creds = new SigningCredentials(keye, SecurityAlgorithms.HmacSha512);

                var tokendescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = creds
                };

                var tokenhandler = new JwtSecurityTokenHandler();
                var token1 = tokenhandler.CreateToken(tokendescriptor);
                return Ok(new
                {
                    token = tokenhandler.WriteToken(token1)
                });

            }
            return Ok("not valid");

        }

    }
}