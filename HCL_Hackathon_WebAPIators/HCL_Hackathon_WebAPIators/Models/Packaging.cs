using System.Collections.Generic;

namespace HCL_Hackathon_WebAPIators.Models
{
    public class Packaging
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;

        // Navigation Properties
        public List<Product> Products { get; set; } = new();
    }
}
