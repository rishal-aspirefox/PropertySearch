namespace PropertySearch.Application.Dto
{
    public class SpaceFilterDto
    {
        public Guid? PropertyId { get; set; }

        public string? Type { get; set; }

        public float? MinSize { get; set; }

        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 10;
    }
}
