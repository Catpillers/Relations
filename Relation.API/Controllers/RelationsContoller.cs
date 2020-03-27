using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Relation.API.Models;
using Relations.Bll.Interfaces;

namespace Relation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelationsController : ControllerBase
    {
        private readonly IRelationService _service;
        private readonly IMapper _mapper;

        public RelationsController(IRelationService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetRelations([FromQuery]RelationParams relationParams)
        {
            var relations = await _service.GetList(relationParams.CategoryId);
            var relationToReturn = _mapper.Map<IEnumerable<RelationVm>>(relations);
            return Ok(relationToReturn);
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetRelation(Guid id)
        //{
        //    var relations = await _service.GetById(id);
        //    var relationsToReturn = _mapper.Map<RelationVm>(relations);
        //    return Ok(relationsToReturn);
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateRelation(Guid id, RelationVm relationVm)
        //{
        //    var relation = await _service.GetById(id);
        //    _mapper.Map(relationVm, relation);
        //    if (await _service.SaveAll())
        //    {
        //        return NoContent();
        //    }

        //    throw new Exception($"Updating user {id} failed on save");
        //}
    }
}