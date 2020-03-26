using Relations.Dal.Data;
using Relations.Dal.Models;

namespace Relations.Dal.Repository
{
    public class CategoryRepository : AsyncRepository<Category>
    {
        public CategoryRepository(DataContext context) : base(context)
        {
        }
    }
}