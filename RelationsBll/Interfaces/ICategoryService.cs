﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Relations.Dal.Models;

namespace Relations.Bll.Interfaces
{
  public  interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategoriesList();
    }
}
