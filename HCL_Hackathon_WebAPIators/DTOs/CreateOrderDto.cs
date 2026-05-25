using System.ComponentModel.DataAnnotations;

namespace HCL_Hackathon_WebAPIators.DTOs
{
    public class CreateOrderDto
    {
        [Required]
        [Range(1, 100000)]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(100)]
        public string ItemName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Category { get; set; } = string.Empty;
    }
}