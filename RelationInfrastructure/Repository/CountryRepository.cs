using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Relations.Dal.Data;
using Relations.Dal.Interfaces;
using Relations.Dal.Models;

namespace Relations.Dal.Repository
{
   public class CountryRepository : AsyncRepository<Country>, ICountryRepository
   { 
       public CountryRepository(DataContext context) : base(context) {}
   }
}
