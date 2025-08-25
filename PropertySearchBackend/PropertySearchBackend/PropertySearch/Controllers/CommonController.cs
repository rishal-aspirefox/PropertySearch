using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PropertySearch.Application.Dto;
using PropertySearch.Application.Services;

namespace PropertySearch.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CommonController : ControllerBase
    {
        private readonly ICommonService _commonService;

        public CommonController(ICommonService commonService)
        {
            _commonService = commonService;
        }

        [HttpGet]
        public async Task<ServiceResponse<List<CountryDto>>> GetAllCountries()
        {
            try
            {
                var countries = await _commonService.GetAllCountries();
                return countries;
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<CountryDto>>.Failure(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ServiceResponse<List<StateDto>>> GetAllStates(Guid countryId)
        {
            try
            {
                var states = await _commonService.GetAllStates(countryId);
                return states;
            }
            catch (Exception ex)
            {
                return ServiceResponse<List<StateDto>>.Failure(ex.Message);
            }
        }
    }
}
