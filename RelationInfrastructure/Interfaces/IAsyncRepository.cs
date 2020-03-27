using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Relations.Dal.Models;

namespace Relations.Dal.Interfaces
{
    public interface IAsyncRepository<T> where T : EntityWithId
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task Add(T entity);
        Task Remove(T entity);
    }
}