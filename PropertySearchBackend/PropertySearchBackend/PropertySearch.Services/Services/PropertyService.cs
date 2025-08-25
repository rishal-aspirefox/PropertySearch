using Microsoft.EntityFrameworkCore;
using PropertySearch.Application.Dto;
using PropertySearch.Application.Enums;
using PropertySearch.Application.ResponseAppMessage;
using PropertySearch.Core.Entities;
using PropertySearch.Core.Interfaces;

namespace PropertySearch.Application.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IRepository<Property> _propertyRepository;

        public PropertyService(IRepository<Property> propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public async Task<ServiceResponse<PropertyListResponseDto>> GetProperties(PropertyFilterDto filter)
        {
            if (filter.MinPrice.HasValue && filter.MaxPrice.HasValue && filter.MinPrice > filter.MaxPrice)
                return ServiceResponse<PropertyListResponseDto>.Failure(AppMessage.Property.NotFound);

            var query = _propertyRepository.GetAllIncluding(p => p.Spaces);

            if (!string.IsNullOrEmpty(filter.Type))
                query = query.Where(p => p.Type.ToLower() == filter.Type.ToLower());

            if (filter.MinPrice.HasValue)
                query = query.Where(p => p.Price >= filter.MinPrice.Value);

            if (filter.MaxPrice.HasValue)
                query = query.Where(p => p.Price <= filter.MaxPrice.Value);

            query = !string.IsNullOrEmpty(filter.SortBy) && filter.SortBy.ToLower() == "desc"
                ? query.OrderByDescending(p => p.Price)  
                : query.OrderBy(p => p.Price);

            var totalCount = await query.CountAsync();

            var properties = await query
                .Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .Select(p => new PropertyDto
                {
                    Id = p.Id,
                    Type = p.Type,
                    Price = p.Price,
                    Description = p.Description,
                    Address = p.Address,
                    City = p.City,
                    PostalCode = p.PostalCode,
                    StateId = p.StateId,
                    CountryId = p.CountryId,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt,
                    Spaces = p.Spaces.Select(s => new SpaceDto
                    {
                        Id = s.Id,
                        Type = s.Type,
                        Size = s.Size,
                        Description = s.Description,
                        CreatedAt = s.CreatedAt,
                        UpdatedAt = s.UpdatedAt
                    }).ToList()
                })
                .ToListAsync();

            var data = new PropertyListResponseDto
            {
                Properties = properties,
                TotalCount = totalCount,
                Page = filter.Page,
                PageSize = (int)Math.Ceiling((double)totalCount / filter.PageSize)
            };

            return ServiceResponse<PropertyListResponseDto>.Success(data);
        }

        public async Task<ServiceResponse<PropertyDto>> GetPropertyById(Guid id)
        {
            var property = await _propertyRepository.GetAllIncluding(p => p.Spaces).FirstOrDefaultAsync(p => p.Id == id);

            if (property == null)
                return ServiceResponse<PropertyDto>.Failure(AppMessage.Property.NotFound);

            var data = MapPropertyToDto(property);
            return ServiceResponse<PropertyDto>.Success(data);
        }

        public async Task<ServiceResponse<PropertyDto>> CreateProperty(CreatePropertyDto propertyDto)
        {
            if (string.IsNullOrWhiteSpace(propertyDto.Type) || propertyDto.Price <= 0 ||
                string.IsNullOrWhiteSpace(propertyDto.Address) || string.IsNullOrWhiteSpace(propertyDto.City))
            {
                return ServiceResponse<PropertyDto>.Failure(AppMessage.AllFieldsRequired);
            }
            PropertyType propertyType = ParseEnum<PropertyType>(propertyDto.Type);

            var newProperty = new Property
            {
                Id = Guid.NewGuid(),
                Type = propertyType.ToString(),
                Price = propertyDto.Price,
                Description = propertyDto.Description,
                Address = propertyDto.Address,
                City = propertyDto.City,
                PostalCode = propertyDto.PostalCode,
                StateId = propertyDto.StateId,
                CountryId = propertyDto.CountryId,
                CreatedAt = DateTime.UtcNow,
                Spaces = new List<Space>()
            };

            if (propertyDto.Spaces != null && propertyDto.Spaces.Any())
            {
                foreach (var spaceDto in propertyDto.Spaces)
                {
                    if (string.IsNullOrWhiteSpace(spaceDto.Type) || spaceDto.Size <= 0)
                        return ServiceResponse<PropertyDto>.Failure(AppMessage.AllFieldsRequired);
                    SpaceType spaceType = ParseEnum<SpaceType>(spaceDto.Type);

                    newProperty.Spaces.Add(new Space
                    {
                        Id = Guid.NewGuid(),
                        Type = spaceType.ToString(),
                        Size = spaceDto.Size,
                        PropertyId = newProperty.Id,
                        Description = spaceDto.Description,
                        CreatedAt = DateTime.UtcNow,
                    });
                }
            }

            await _propertyRepository.AddAsync(newProperty);
            await _propertyRepository.SaveAsync();

            var data = MapPropertyToDto(newProperty);
            return ServiceResponse<PropertyDto>.Success(data);
        }

        public static T ParseEnum<T>(string value) where T : struct, Enum
        {
            if (Enum.TryParse<T>(value, ignoreCase: true, out var result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException($"Invalid value '{value}' for enum {typeof(T).Name}");
            }
        }

        private PropertyDto MapPropertyToDto(Property property)
        {
            if (property == null) return null;

            return new PropertyDto
            {
                Id = property.Id,
                Type = property.Type,
                Price = property.Price,
                Description = property.Description,
                Address = property.Address,
                City = property.City,
                PostalCode = property.PostalCode,
                StateId = property.StateId,
                CountryId = property.CountryId,
                CreatedAt = property.CreatedAt,
                UpdatedAt = property.UpdatedAt,
                Spaces = property.Spaces?.Select(s => new SpaceDto
                {
                    Id = s.Id,
                    Type = s.Type,
                    Size = s.Size,
                    Description = s.Description,
                    CreatedAt = s.CreatedAt,
                    UpdatedAt = s.UpdatedAt
                }).ToList() ?? new List<SpaceDto>()
            };
        }
    }
}
