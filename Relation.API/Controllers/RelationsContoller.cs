using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Relations.Dal.Interfaces;

namespace Relations.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelationsController : ControllerBase
    {
        private readonly IRelationRepository _repo;

        public RelationsController(IRelationRepository repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var relation = await _repo.GetRelation();
            return Ok(relation);

        }



    }
}
