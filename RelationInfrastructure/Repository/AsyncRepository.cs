using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Relations.Dal.Interfaces;
using Relations.Dal.Models;

namespace Relations.Dal.Repository
{
    public class AsyncRepository<T> : IAsyncRepository<T> where T : EntityWithId
    {
        protected readonly DbContext _context;

        public AsyncRepository(DbContext context)
        {
            _context = context;
        }

        public virtual async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public Task<T> GetById(Guid id)
        {
            return _context.Set<T>().FindAsync(id);
        }

        public Task Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            return _context.SaveChangesAsync();
        }

    }
}