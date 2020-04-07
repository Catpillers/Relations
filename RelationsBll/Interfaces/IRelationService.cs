using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Relations.API.ViewModels;
using Relations.Dal.Helpers;
using Relations.Dal.ModelsToModify;

namespace Relations.Bll.Interfaces
{
    public interface IRelationService 
   {
        Task<PaginatedList<RelationVm>> GetRelationsList(Guid? categoryId, int? pageNumber, string sortField, string sortOrder);
        Task AddRelation(AddRelationModel model);
        string ApplyMask(string value, string mask);
        Task UpdateRelation(UpdateRelationModel modelToUpdate);
        Task DisableRelation(IEnumerable<Guid> relationId);
   }
}