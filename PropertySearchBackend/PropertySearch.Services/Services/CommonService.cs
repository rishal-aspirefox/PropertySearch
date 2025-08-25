using Microsoft.EntityFrameworkCore;
using PropertySearch.Application.Dto;
using PropertySearch.Application.ResponseAppMessage;
using PropertySearch.Core.Entities;
using PropertySearch.Core.Interfaces;

namespace PropertySearch.Application.Services
{
    public class CommonService : ICommonService
    {
        private readonly IRepository<Country> _countryRepository;
        private readonly IRepository<State> _stateRepository;

        public CommonService(IRepository<Country> countryRepository, IRepository<State> stateRepository)
        {
            _countryRepository = countryRepository;
            _stateRepository = stateRepository;
        }

        public async Task<ServiceResponse<List<CountryDto>>> GetAllCountries()
        {
            var countries = await _countryRepository.GetAll()
                .Select(c => new CountryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Code = c.Code
                })
                .ToListAsync();

            if (!countries.Any())
                return ServiceResponse<List<CountryDto>>.Failure(AppMessage.Country.CountriesNotFound);

            return ServiceResponse<List<CountryDto>>.Success(countries);
        }

        public async Task<ServiceResponse<List<StateDto>>> GetAllStates(Guid countryId)
        {
            var states = await _stateRepository.GetAllIncluding(s => s.Country)
                .Where(s => s.CountryId == countryId)
                .Select(s => new StateDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Code = s.Code
                })
                .ToListAsync();

            if (!states.Any())
                return ServiceResponse<List<StateDto>>.Failure(AppMessage.Country.StatesNotFound);

            return ServiceResponse<List<StateDto>>.Success(states);
        }
    }
}
