using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Relations.Bll.Interfaces;
using Relations.Dal.Interfaces;
using Relations.Dal.Models;

namespace Relations.Bll.Services
{
  public  class CountryService : ICountryService
    {
        private readonly IAsyncRepository<Country> _country;

        public CountryService(IAsyncRepository<Country> country)
        {
            _country = country;
        }

        public async Task<IEnumerable<Country>> GetCountriesList()
        {
            return await _country.GetAll();
        }

        public async Task<Country> GetCountry(Guid countryId)
        {
            return await _country.GetById(countryId);
        }
    }
}
