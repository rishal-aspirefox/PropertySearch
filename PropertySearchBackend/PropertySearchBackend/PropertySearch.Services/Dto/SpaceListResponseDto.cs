namespace PropertySearch.Application.Dto
{
    public class SpaceListResponseDto
    {
        public List<SpaceDto> Spaces { get; set; }

        public int TotalCount { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
