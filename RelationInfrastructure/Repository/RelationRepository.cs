using System.Collections.Generic;
using System.Linq;
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

       


        
        public async Task<List<Relation>> GetRelation()
        {
            var relation = await _context.Relations
                .Include(_ => _.RelationAddresses)
                .ThenInclude(_ =>_.Country)
                .ToListAsync();
            return relation;
        }
    }
    

}
