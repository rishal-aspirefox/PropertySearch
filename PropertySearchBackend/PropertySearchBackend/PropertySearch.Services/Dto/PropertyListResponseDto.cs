namespace PropertySearch.Application.Dto
{
    public class PropertyListResponseDto
    {
        public List<PropertyDto> Properties { get; set; }

        public int TotalCount { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
