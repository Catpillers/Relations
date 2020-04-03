using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Relations.API.ViewModels;
using Relations.Dal.Interfaces;
using Relations.Dal.Models;
using Relations.Dal.ModelsToModify;

namespace Relations.Bll.Interfaces
{ 
   public interface IRelationService 
   {
        Task<PaginatedList<Relation>> GetRelationsList(Guid? categoryId, int? pageNumber, string sortField, string sortOrder);
        Task AddRelation(AddRelationModel model);
        Task UpdateRelation(UpdateRelationModel modelToUpdate);
        Task DisableRelation(IEnumerable<Guid> relationId);
   }
}