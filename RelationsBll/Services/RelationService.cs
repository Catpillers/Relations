using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Relations.API.ViewModels;
using Relations.Bll.Interfaces;
using Relations.Dal.Interfaces;
using Relations.Dal.Models;
using Relations.Dal.ModelsToModify;

namespace Relations.Bll.Services
{
    public class RelationService : IRelationService
    {
        private readonly IRelationRepository _relations;
       
        public RelationService( IRelationRepository relations)
        { 
            _relations = relations;
        }

        public async Task<PaginatedList<Relation>> GetRelationsList(Guid? categoryId, int? pageNumber, string sortField, string sortOrder)
        {
            return await _relations.GetRelationList(categoryId, pageNumber, sortField, sortOrder);
        }

        public async Task AddRelation(AddRelationModel relationModel)
        {
            await _relations.AddRelation(relationModel);
        }

        public async Task UpdateRelation(UpdateRelationModel modelToUpdate)
        {
            await _relations.UpdateRelation(modelToUpdate);
        }

        public async Task DisableRelation(IEnumerable<Guid> relationIds)
        {
            await _relations.DisableRelations(relationIds);
        }
    }
}
