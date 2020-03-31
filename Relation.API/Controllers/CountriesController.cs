using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Relations.API.ViewModels;
using Relations.Bll.Interfaces;

namespace Relations.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _service;
        private readonly IMapper _mapper;

        public CountriesController(ICountryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            var countries = await _service.GetCountriesList();
            var countriesToDisplay = _mapper.Map<IEnumerable<CountryVm>>(countries);
            return Ok(countriesToDisplay);
        }

    }
}