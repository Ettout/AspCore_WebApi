using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EF.DAL.Data;
using EF.DAL.Data.DataService;
using EF.DAL.Model;
using EF.DAL.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projet_WebApi_1.Dtos;

namespace projet_WebApi_1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;

        public CategoryController(IMapper mapper)
        {
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IDataService<Category> _dataService = new CategoryData();

            var categories = await _dataService.GetALL();
            return Ok(_mapper.Map<List<CategoryReadDto>>(categories));
        }




        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            IDataService<Category> _dataService = new CategoryData();

            var result = await _dataService.GetALL();
            var category = result.FirstOrDefault(x => x.ID == Id);
            return Ok(_mapper.Map<CategoryReadDto>(category));
        }
    }
}