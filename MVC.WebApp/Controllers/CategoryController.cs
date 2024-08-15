using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.WebApp.Models;

namespace MVC.WebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.GetData());
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(string id)
        {
            var category = _repository.GetById(id);
            if (category is not null)
            {
                return Ok(category);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CategoryUpsertDto CategoryDto)
        {
            var category = new Category
            {
                CategoryName = CategoryDto.CategoryName,
                Description = CategoryDto.Description,
            };

            var resultcategory = _repository.Create(category);

            if (resultcategory is not null)
            {
                return Created($"baseurl", resultcategory.CategoryID);
            }
            return BadRequest();
        }
    }
}
