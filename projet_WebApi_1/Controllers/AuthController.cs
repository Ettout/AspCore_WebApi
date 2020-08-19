using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF.DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Register(UserDtos user)
        {
            if (await _autoRepository.UserExist(user.username))
            {
                return StatusCode(401);
            }
            User userCre = new User { Name = user.username, PassWord = user.userpassword };
            await _autoRepository.Register(userCre);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDtos user)
        {
            var result = await _autoRepository.Login(user.username, user.userpassword);
            if (result == true)
            {
                Token token1 = new Token { tokenn = "valid token" };
                return Ok(token1);
            }
            Token token2 = new Token { tokenn = "-----------------" };
            return Ok(token2);
        }

    }
}