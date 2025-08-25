using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropertySearch.Core.Entities
{
    public class Property : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(50)]
        public string Type { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [MaxLength]
        public string? Description { get; set; }

        [Required, MaxLength(255)]
        public string Address { get; set; } = null!;

        [Required, MaxLength(255)]
        public string City { get; set; } = null!;

        [Required, MaxLength(10)]
        public string PostalCode { get; set; } = null!;

        [Required]
        public Guid StateId { get; set; }

        [ForeignKey(nameof(StateId))]
        public State State { get; set; } = null!;

        [Required]
        public Guid CountryId { get; set; }

        [ForeignKey(nameof(CountryId))]
        public Country Country { get; set; } = null!;

        public ICollection<Space>? Spaces { get; set; } = new List<Space>();
    }
}
