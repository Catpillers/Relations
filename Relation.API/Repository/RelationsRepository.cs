using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Relation.API.Data;
using Relation.API.Models;
using Relation.API.Services;

namespace Relation.API.Repository
{
    public class RelationsRepository : IRelationRepository
    {
        private readonly DataContext _context;

        public RelationsRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Models.Relation>> GetRelations()
        {
            var relations = await _context.TblRelation.ToListAsync();
            return relations;
        }

        public async Task<IEnumerable<Country>> GetCountry()
        {
            var countries = await _context.TblCountry.ToListAsync();
            return countries;
        }
    

        public async Task<IEnumerable<Category>> GetCategory()
        {
            var categories = await _context.TblCategory.ToListAsync();
            return categories;
        }


        public async Task<IEnumerable<AddressType>> GetAddressType()
        {
            var address = await _context.TblAddressType.ToListAsync();
            return address;
        }

        public async Task<IEnumerable<RelationAddress>> GetRelationAddress()
        {
            var relationAddresses = await _context.TblRelationAddress.ToListAsync();
            return relationAddresses;
        }


        public async Task<IEnumerable<RelationCategory>> GetRelationCategory()
        {
            var relationCategories = await _context.TblRelationCategory.ToListAsync();
            return relationCategories;
        }

    }
    
}
