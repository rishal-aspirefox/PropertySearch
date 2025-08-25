using Microsoft.EntityFrameworkCore;
using PropertySearch.Application.Dto;
using PropertySearch.Application.ResponseAppMessage;
using PropertySearch.Core.Entities;
using PropertySearch.Core.Interfaces;

namespace PropertySearch.Application.Services
{
    public class SpaceService : ISpaceService
    {
        private readonly IRepository<Space> _spaceRepository;

        public SpaceService(IRepository<Space> spaceRepository)
        {
            _spaceRepository = spaceRepository;
        }

        public async Task<ServiceResponse<SpaceListResponseDto>> GetSpaces(SpaceFilterDto filter)
        {
            if (filter.Page < 1) filter.Page = 1;
            if (filter.PageSize < 1) filter.PageSize = 10;
            if (filter.PageSize > 100) filter.PageSize = 100;

            var query = _spaceRepository.GetAll();

            if (filter.PropertyId.HasValue)
                query = query.Where(s => s.PropertyId == filter.PropertyId.Value);

            if (!string.IsNullOrEmpty(filter.Type))
                query = query.Where(s => s.Type.ToLower().Contains(filter.Type.ToLower()));

            if (filter.MinSize.HasValue)
                query = query.Where(s => s.Size >= filter.MinSize.Value);

            var totalCount = await query.CountAsync();

            var spaces = await query
                .OrderBy(s => s.CreatedAt)
                .Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .Select(s => new SpaceDto
                {
                    Id = s.Id,
                    Type = s.Type,
                    Size = s.Size,
                    Description = s.Description,
                    CreatedAt = s.CreatedAt,
                    UpdatedAt = s.UpdatedAt
                })
                .ToListAsync();

            var data = new SpaceListResponseDto
            {
                Spaces = spaces,
                TotalCount = totalCount,
                Page = filter.Page,
                PageSize = filter.PageSize,
            };

            return ServiceResponse<SpaceListResponseDto>.Success(data);
        }

        public async Task<ServiceResponse<AverageSpaceResponseDto>> GetAverageSpaceSize(Guid propertyId)
        {
            var query = _spaceRepository.GetAll()
                .Where(s => s.PropertyId == propertyId);

            var totalSpaces = await query.CountAsync();
            if (totalSpaces == 0)
            {
                return ServiceResponse<AverageSpaceResponseDto>.Failure(AppMessage.Spaces.PropertySpacesNotFound);
            }

            var data = new AverageSpaceResponseDto
            {
                TotalSpaces = totalSpaces,
                AverageSize = await query.AverageAsync(s => s.Size),
                MaxSize = await query.MaxAsync(s => s.Size),
                MinSize = await query.MinAsync(s => s.Size)
            };

            return ServiceResponse<AverageSpaceResponseDto>.Success(data);
        }
    }
}
