using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Relations.Bll.Interfaces;
using Relations.Dal.Interfaces;
using Relations.Dal.Models;

namespace Relations.Bll.Services
{
    public class RelationService : IRelationService
    {
        private readonly IAsyncRepository<Relation> _repo;
       
        public RelationService(IAsyncRepository<Relation> repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Relation>> GetAll(Guid? id)
        { 
            var relations =  await _repo.GetAll();
            return relations.AsQueryable().Where(_ => _.RelationCategories.FirstOrDefault().CategoryId == id);
        }

    }
}
