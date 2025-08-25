using PropertySearch.Application.Dto;

namespace PropertySearch.Application.Services
{
    public interface ICommonService
    {
        Task<ServiceResponse<List<CountryDto>>> GetAllCountries();

        Task<ServiceResponse<List<StateDto>>> GetAllStates(Guid countryId);
    }
}
