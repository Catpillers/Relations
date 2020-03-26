using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Relations.Dal.Data;
using Relations.Dal.Models;

namespace Relations.Dal.Repository
{
    public class RelationRepository : AsyncRepository<Relation>
    {
        public RelationRepository(DataContext context) : base(context){}

        public override async Task<IEnumerable<Relation>> GetAll()
        {
              return await _context.Set<Relation>()
                .Include(_ => _.RelationCategories)
                .Include(_ => _.RelationAddresses)
                .ThenInclude(_ => _.Country).ToListAsync();

        }
    }
}