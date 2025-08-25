using System.ComponentModel.DataAnnotations;

namespace PropertySearch.Core.Entities
{
    public class Country
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required, MaxLength(3)]
        public string Code { get; set; } = null!;

        public ICollection<Property> Properties { get; set; } = new List<Property>();

        public ICollection<State> States { get; set; } = new List<State>();

    }
}
