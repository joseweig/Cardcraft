using Cardcraft.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cardcraft.Data.Models
{
    public class Card
    {
        public int Id { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Name is too long.")]
        public string? Name { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Description is too long.")]
        public string? Description { get; set; }

        public FamilyType Family { get; set; }

        [Required]
        [Range(0, 12, ErrorMessage = "Value must be between 0 and 10.")]
        public int Cost { get; set; } = 1;

        [Required]
        [Range(0, 12, ErrorMessage = "Value must be between 0 and 10.")]
        public int Attack { get; set; } = 1;

        [Required]
        [Range(1, 12, ErrorMessage = "Value must be between 1 and 10.")]
        public int Health { get; set; } = 1;

        public string? Image { get; set; }

        public bool IsActive { get; set; } = true;

        [NotMapped]
        public bool NewImageCreated { get; set; } = false;
    }
}
