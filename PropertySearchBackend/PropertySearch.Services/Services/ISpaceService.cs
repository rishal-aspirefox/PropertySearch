using PropertySearch.Application.Dto;

namespace PropertySearch.Application.Services
{
    public interface ISpaceService
    {
        Task<ServiceResponse<SpaceListResponseDto>> GetSpaces(SpaceFilterDto filter);

        Task<ServiceResponse<AverageSpaceResponseDto>> GetAverageSpaceSize(Guid propertyId);
    }
}