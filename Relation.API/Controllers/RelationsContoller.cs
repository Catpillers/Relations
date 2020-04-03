using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Relations.API.ViewModels;
using Relations.Bll.Interfaces;
using Relations.Dal.ModelsToModify;


namespace Relations.API.Controllers
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
        public async Task<IActionResult> GetRelations([FromQuery]Guid? categoryId,int? pageNumber, string sortField, string sortOrder)
        {
            var relations = await _service.GetRelationsList(categoryId, pageNumber, sortField, sortOrder);
            var relationList = _mapper.Map<List<RelationVm>>(relations.Items);
            var relationToReturn = new PaginatedList<RelationVm>(relationList, relations.TotalCount);
            return Ok(relationToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> AddRelations(AddRelationModel relationToAdd)
        { 
            await _service.AddRelation(relationToAdd);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> EditRelation(UpdateRelationModel modelToUpdate)
        {
            await _service.UpdateRelation(modelToUpdate);
            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> Disable(IEnumerable<Guid> ids)
        {
            await _service.DisableRelation(ids);
            return NoContent();
        }
    }
}