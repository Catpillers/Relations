using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Relations.API.Dto;
using Relations.Dal.Interfaces;

namespace Relations.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelationsController : ControllerBase
    {
        private readonly IRelationRepository _repo;
        private readonly IMapper _mapper;

        public RelationsController(IRelationRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var relations = await _repo.GetRelation();
            var relationToReturn = _mapper.Map<IEnumerable<RelationToDisplayDto>>(relations);
            return Ok(relationToReturn);

        }


        //[HttpGet]
        //public async Task<IActionResult> GetById()
        //{
        //    var relation = (await _repo.GetRelation()).First();
        //    var relationToReturn = _mapper.Map<RelationToDisplayDto>(relation);
        //    return Ok(relationToReturn);

        //}



    }
}