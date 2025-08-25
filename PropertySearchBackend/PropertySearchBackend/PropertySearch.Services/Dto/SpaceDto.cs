namespace PropertySearch.Application.Dto
{
    public class SpaceDto
    {
        public Guid Id { get; set; }

        public string Type { get; set; }

        public float Size { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
