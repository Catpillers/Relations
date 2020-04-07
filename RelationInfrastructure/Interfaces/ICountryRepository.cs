using System;
using System.Collections.Generic;
using System.Text;
using Relations.Dal.Models;

namespace Relations.Dal.Interfaces
{
  public  interface ICountryRepository : IAsyncRepository<Country>
    {

    }
}
