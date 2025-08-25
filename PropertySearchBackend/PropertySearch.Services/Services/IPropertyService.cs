using PropertySearch.Application.Dto;

namespace PropertySearch.Application.Services
{
    public interface  IPropertyService
    {
        Task<ServiceResponse<PropertyListResponseDto>> GetProperties(PropertyFilterDto filter);

        Task<ServiceResponse<PropertyDto>> GetPropertyById(Guid id);

        Task<ServiceResponse<PropertyDto>> CreateProperty(CreatePropertyDto propertyDto);
    }
}
