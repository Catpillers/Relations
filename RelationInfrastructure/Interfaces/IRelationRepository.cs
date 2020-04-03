using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Relations.API.ViewModels;
using Relations.Dal.Models;
using Relations.Dal.ModelsToModify;

namespace Relations.Dal.Interfaces
{
    public interface IRelationRepository : IAsyncRepository<Relation>
    {
        Task<PaginatedList<RelationVm>> GetRelationList(Guid? categoryId, int? pageNumber, string sortField, string sortOrder);
        Task UpdateRelation(UpdateRelationModel relationToUpdate);
        Task DisableRelations(IEnumerable<Guid> ids);
        Task AddRelation(AddRelationModel relationModel);
    }
}