using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Relations.Dal.Data;
using Relations.Dal.Models;

namespace Relations.Dal.Repository
{
   public class CountryRepository : AsyncRepository<Country>
   {
        public CountryRepository(DataContext context) : base(context) {}
   }
}
