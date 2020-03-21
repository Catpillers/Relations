using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Relation.API.Services
{
    public interface IRelationRepository
    {
        Task<IEnumerable<Models.Relation>> GetRelations();
        Task<IEnumerable<Models.Country>> GetCountry();
        Task<IEnumerable<Models.Category>> GetCategory();
        Task<IEnumerable<Models.AddressType>> GetAddressType();
        Task<IEnumerable<Models.RelationAddress>> GetRelationAddress();
        Task<IEnumerable<Models.RelationCategory>> GetRelationCategory();


    }
}
