using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PropertySearch.Application.Dto;
using PropertySearch.Application.Services;

namespace PropertySearch.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class SpacesController : ControllerBase
    {
        private readonly ISpaceService _spaceService;

        public SpacesController(ISpaceService spaceService)
        {
            _spaceService = spaceService;
        }

        [HttpGet]
        public async Task<ServiceResponse<SpaceListResponseDto>> GetSpaces([FromQuery] SpaceFilterDto filter)
        {
            try
            {
                var result = await _spaceService.GetSpaces(filter);
                return result;
            }
            catch (Exception ex)
            {
                return ServiceResponse<SpaceListResponseDto>.Failure(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ServiceResponse<AverageSpaceResponseDto>> GetAverageSpaceSize(Guid propertyId)
        {
            try
            {
                var spaceSize = await _spaceService.GetAverageSpaceSize(propertyId);
                return spaceSize;
            }
            catch (Exception ex)
            {
                return ServiceResponse<AverageSpaceResponseDto>.Failure(ex.Message);
            }
        }
    }
}