using System.Linq;
using System.Threading.Tasks;
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

        public UserController(IAutoRepository autoRepository)
        {
            _autoRepository = autoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IDataService<User> _dataService = new UserData();

            var result = await _dataService.GetALL();
            return Ok(result);
        }




        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            IDataService<User> _dataService = new UserData();

            var result = await _dataService.GetALL();
            var res1 = result.FirstOrDefault(x => x.ID == Id);
            return Ok(res1);
        }


    }
}