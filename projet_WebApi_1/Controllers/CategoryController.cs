using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF.DAL.Data;
using EF.DAL.Data.DataService;
using EF.DAL.Model;
using EF.DAL.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace projet_WebApi_1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IDataService<Category> _dataService = new CategoryData();

            var result = await _dataService.GetALL();
            return Ok(result);
        }




        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            IDataService<Category> _dataService = new CategoryData();

            var result = await _dataService.GetALL();
            var res1 = result.FirstOrDefault(x => x.ID == Id);
            return Ok(res1);
        }
    }
}