using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EF.DAL.Data;
using EF.DAL.Model;
using EF.DAL.Service;
using Microsoft.AspNetCore.Mvc;
using projet_WebApi_1.Dtos;
using projet_WebApi_1.Service;

namespace projet_WebApi_1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAutoRepository _autoRepository;
        private readonly IMapper _mapper;

        public UserController(IAutoRepository autoRepository, IMapper mapper)
        {
            _autoRepository = autoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IDataService<User> _dataService = new UserData();

            var result = await _dataService.GetALL();
            return Ok(_mapper.Map<List<UserReadDto>>(result)); ;
        }




        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            IDataService<User> _dataService = new UserData();

            var result = await _dataService.GetALL();
            var res1 = result.FirstOrDefault(x => x.ID == Id);
            return Ok(_mapper.Map<UserReadDto>(res1));
        }

        /* [HttpPost("add")]
         public async Task<IActionResult> Add(UserADtos userADtos)
         {


             IDataService<User> _dataService = new UserData();

             User user = new User
             {
                 Name = userADtos.Username,
                 Prename = userADtos.Userprename,
                 EmailAdress = userADtos.Useremail,
                 Tel = userADtos.Usertel,
                 PassWord = userADtos.Userpassword,
             };

             var result = await _dataService.Create(user);
             return Ok(result);
         }
        */
    }
}