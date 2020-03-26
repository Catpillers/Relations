using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Relations.API.RelationsViewModels;
using Relations.Dal.Interfaces;
using Relations.Dal.Models;

namespace Relations.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IAsyncRepository<Category> _repo;
        private readonly IMapper _mapper;

        public CategoriesController(IAsyncRepository<Category> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategory()
        {
            var category = await _repo.GetAll();
            var categoryToDisplay = _mapper.Map<IEnumerable<CategoryVm>>(category);
            return Ok(categoryToDisplay);
        }
    }
}