using System.Collections.Generic;
using System.Threading.Tasks;
using Relations.Dal.Models;

namespace Relations.Dal.Interfaces
{
    public interface IRelationRepository
    {  
        Task<IEnumerable<Relation>> GetRelation();
       

        //void Create(T record);

        //void Update(T record);

        //void Delete(Guid id);

        //int Save();

        //Task<int> SaveAsync();



    }
}
