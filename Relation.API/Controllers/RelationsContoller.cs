using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Relation.API.Models;
using Relation.API.Services;

namespace Relation.API.Controllers
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
        public async Task<IActionResult> GetRelations()
        {
            var relation = await _repo.GetAddressType();
            return Ok(relation);
        }
    }
}
