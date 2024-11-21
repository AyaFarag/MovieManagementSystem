using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieSystem.Application.Contracts.Interface;
using MovieSystem.Application.Contracts.Service;
using MovieSystem.Application.DTO;

namespace MovieSystem.API.Controllers
{
    // [EnableCors("CustomPolicy")]
    [DisableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;  
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cats = await _categoryService.GetALlCategories();
            return Ok(cats);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cat = await _categoryService.GetCategoryById(id);
            return Ok(cat);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryDTO catDTO)
        {

            var result = await _categoryService.CreateCategory(catDTO);
            return Ok(result);
        }
    }
}
