namespace PropertySearch.Application.Dto
{
    public class CreatePropertyDto
    {
        public string Type { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public Guid StateId { get; set; }

        public Guid CountryId { get; set; }

        public List<CreateSpaceDto>? Spaces { get; set; }
    }
}
