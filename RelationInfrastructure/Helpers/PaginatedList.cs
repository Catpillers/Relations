using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Relations.Dal.Helpers
{
  public  class PaginatedList<T> 
  { 
        public int TotalCount { get; }
        public List<T> Items { get; }

        public PaginatedList(List<T> items, int totalCount)
        {
            TotalCount = totalCount;
            Items = new List<T>();
            Items.AddRange(items);
        }

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var totalCount = await source.CountAsync();

            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, totalCount);
        }
    }
}
