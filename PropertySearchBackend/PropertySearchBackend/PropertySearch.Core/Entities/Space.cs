using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropertySearch.Core.Entities
{
    public class Space : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(50)]
        public string Type { get; set; } = null!;

        [Required]
        public float Size { get; set; }

        [MaxLength]
        public string? Description { get; set; }

        public Guid? PropertyId { get; set; }

        [ForeignKey(nameof(PropertyId))]
        public Property? Property { get; set; }
    }
}
