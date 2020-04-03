using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Relations.API.ViewModels;
using Relations.Dal.Interfaces;
using Relations.Dal.Models;

namespace Relations.Bll.Interfaces
{ 
   public interface IRelationService 
   { 
        Task<IEnumerable<Relation>> GetRelationsList(Guid? categoryId);
        Task AddRelation(AddRelationModel model);
        Task<IEnumerable<Relation>> DisableRelation(IEnumerable<Guid> relationId);
   }
}