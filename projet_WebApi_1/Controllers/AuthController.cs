using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EF.DAL.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using projet_WebApi_1.Dtos;
using projet_WebApi_1.Service;

namespace projet_WebApi_1.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAutoRepository _autoRepository;
        private readonly IMapper _mapper;

        public AuthController(IAutoRepository autoRepository, IMapper mapper)
        {
            _autoRepository = autoRepository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserCreatDto user)
        {
            if (await _autoRepository.UserExist(user.Name))
            {
                return StatusCode(401);
            }

            User userCre = _mapper.Map<User>(user);

            await _autoRepository.Register(userCre, user.PassWord);
            return await Login(new LoginDto { Name = user.Name, Password = user.PassWord });

        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto user)
        {
            var _user = await _autoRepository.Login(user.Name, user.Password);
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
                    token = tokenhandler.WriteToken(token1),
                    userRole = _user.UserRole == UserRoleType.AdminAccount ? "Admin" : "User"
                });

            }
            return Ok("not valid");

        }


    }
}