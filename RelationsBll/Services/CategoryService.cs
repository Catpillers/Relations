using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Relations.Bll.Interfaces;
using Relations.Dal.Interfaces;
using Relations.Dal.Models;

namespace Relations.Bll.Services
{ 
    public class CategoryService : ICategoryService
    {
        private readonly IAsyncRepository<Category> _category;

        public CategoryService(IAsyncRepository<Category> category)
        {
            _category = category;
        }
        public async Task<IEnumerable<Category>> GetCategoriesList()
        {
           return await _category.GetAll();
        }
    }
}
