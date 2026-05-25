using System.ComponentModel.DataAnnotations;

namespace HCL_Hackathon_WebAPIators.DTOs
{
    public class UpdateOrderStatusDto
    {
        [Required]
        public string Status { get; set; } = string.Empty;

        public string? Comment { get; set; }
    }
}