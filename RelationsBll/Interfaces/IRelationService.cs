using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Relations.Dal.Interfaces;
using Relations.Dal.Models;

namespace Relations.Bll.Interfaces
{ 
   public interface IRelationService 
   { 
        Task<IEnumerable<Relation>> GetList(Guid? categoryId);

}  }
