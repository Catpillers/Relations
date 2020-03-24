using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Relations.Dal.Data;
using Relations.Dal.Interfaces;
using Relations.Dal.Models;

namespace Relations.Dal.Repository
{
    public class RelationRepository : IRelationRepository
    {
        private protected DataContext _context;

        public RelationRepository(DataContext context)
        {
            _context = context;
        }

       


        public async Task<IEnumerable<Relation>> GetRelation()
        {
            var relation = await _context.Relations.ToListAsync();
            return relation;
        }
    }

}
