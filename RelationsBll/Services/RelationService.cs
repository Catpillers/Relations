using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Relations.Bll.Interfaces;
using Relations.Dal.Interfaces;
using Relations.Dal.Models;

namespace Relations.Bll.Services
{
    public class RelationService : IRelationService
    {
        private readonly IRelationRepository _relations;
       
        public RelationService( IRelationRepository relations)
        { 
            _relations = relations;
        }

        public async Task<IEnumerable<Relation>> GetList(Guid? categoryId)
        {
            return await _relations.GetRelationList(categoryId);
        }
    }
}
