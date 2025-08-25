using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PropertySearch.Application.Dto;
using PropertySearch.Application.Services;

namespace PropertySearch.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        public PropertiesController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet]
        public async Task<ServiceResponse<PropertyListResponseDto>> GetProperties(
           [FromQuery] PropertyFilterDto filter)
        {
            try
            {
                var result = await _propertyService.GetProperties(filter);
                return result;
            }
            catch (Exception ex)
            {   
                return ServiceResponse<PropertyListResponseDto>.Failure(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ServiceResponse<PropertyDto>> GetProperty(Guid id)
        {
            try
            {
                var property = await _propertyService.GetPropertyById(id);
                return property;
            }
            catch (Exception ex)
            {
                return ServiceResponse<PropertyDto>.Failure(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ServiceResponse<PropertyDto>> CreateProperty([FromBody] CreatePropertyDto propertyDto)
        {
            try
            {
                var createdProperty = await _propertyService.CreateProperty(propertyDto);
                return createdProperty;
            }
            catch (Exception ex)
            {
                return ServiceResponse<PropertyDto>.Failure(ex.Message);
            }
        }
    }
}