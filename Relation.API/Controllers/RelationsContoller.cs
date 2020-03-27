using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Relations.API.ViewModels;
using Relations.Bll.Interfaces;
using Relations.Dal.Models;

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
        public async Task<IActionResult> GetRelations([FromQuery]RelationParams relationParams)
        {
            var relations = await _service.GetList(relationParams.CategoryId);
            var relationToReturn = _mapper.Map<IEnumerable<RelationVm>>(relations);
            return Ok(relationToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> AddRelations(AddRelationParams relationToAdd)
        {
          var relation =  _mapper.Map<Relation>(relationToAdd);
          await _service.AddRelation(relation);
          return Ok();
        }
    }
}