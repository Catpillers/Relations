using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Relations.API.ViewModels;
using Relations.Bll.Interfaces;
using Relations.Bll.Services;
using Relations.Dal.Interfaces;
using Relations.Dal.Models;

namespace Relations.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var category = await _service.GetCategoriesList();
            var categoryToDisplay = _mapper.Map<IEnumerable<CategoryVm>>(category);
            return Ok(categoryToDisplay);
        }
    }
}