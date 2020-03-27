using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Relations.Dal.Models;

namespace Relations.Dal.Interfaces
{
    public interface IRelationRepository : IAsyncRepository<Relation>
    {
        Task<IEnumerable<Relation>> GetRelationList(Guid? categoryId);
    }
}