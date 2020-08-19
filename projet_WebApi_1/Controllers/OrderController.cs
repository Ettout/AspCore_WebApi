using System.Linq;
using System.Threading.Tasks;
using EF.DAL.Data;
using EF.DAL.Model;
using EF.DAL.Service;
using Microsoft.AspNetCore.Mvc;

namespace projet_WebApi_1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IDataService<Order> _dataService = new OrderData();

            var result = await _dataService.GetALL();
            return Ok(result);
        }




        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            IDataService<Order> _dataService = new OrderData();

            var result = await _dataService.GetALL();
            var res1 = result.FirstOrDefault(x => x.ID == Id);
            return Ok(res1);
        }




    }
}