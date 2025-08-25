namespace PropertySearch.Application.Dto
{
    public class PropertyDto
    {
        public Guid Id { get; set; }

        public string Type { get; set; }

        public decimal Price { get; set; }

        public string? Description { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public Guid StateId { get; set; }

        public Guid CountryId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public List<SpaceDto> Spaces { get; set; } = new List<SpaceDto>();
    }
}
