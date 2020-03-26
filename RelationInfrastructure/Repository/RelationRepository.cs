using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Relations.Dal.Data;
using Relations.Dal.Interfaces;
using Relations.Dal.Models;

namespace Relations.Dal.Repository
{
    public class RelationRepository : AsyncRepository<Relation>, IRelationRepository
    {
        public RelationRepository(DataContext context) : base(context){}

        public async Task<IEnumerable<Relation>> GetRelationsToList(Guid? categoryId)
        {
            if (categoryId == null)
            {
                return await _context.Set<Relation>()
                    .Include(_ => _.RelationCategories)
                    .Include(_ => _.RelationAddresses)
                    .ThenInclude(_ => _.Country)
                    .ToListAsync();
            }

            return  await _context.Set<Relation>()
                .Include(_ => _.RelationCategories)
                .Include(_ => _.RelationAddresses)
                .ThenInclude(_ => _.Country)
                .Where(_ => _.RelationCategories.FirstOrDefault().CategoryId == categoryId).ToListAsync();
        }
    }
}