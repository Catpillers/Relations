using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Relations.Dal.ModelsToModify
{
  public  class PaginatedList<T> 
  {
        //public List<T> Items { get; set; }
        //public int CurrentPage { get; set; }
        //public int TotalPages { get; set; }
        //public int PageSize { get; set; }
        //public int TotalCount { get; set; }
        //public PaginatedList(List<T> items, int count, int pageNumber, int pageSize)
        //{
        //    TotalCount = count;
        //    PageSize = pageSize;
        //    CurrentPage = pageNumber;
        //    TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        //    AddRange(items);
        //}

        //public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source,
        //    int pageNumber, int pageSize)
        //{
        //    var count = await source.CountAsync();
        //    var items = await source.Skip((pageNumber - 1) * pageSize)
        //        .Take(pageSize).ToListAsync();
        //    return new PaginatedList<T>(items, count, pageNumber, pageSize);
        //}

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
