using System.Collections.Generic;

namespace HCL_Hackathon_WebAPIators.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Navigation Properties
        public List<Product> Products { get; set; } = new();
    }
}