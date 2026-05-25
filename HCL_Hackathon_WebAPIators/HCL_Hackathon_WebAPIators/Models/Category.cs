using System.Collections.Generic;

namespace HCL_Hackathon_WebAPIators.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Maps Pizza, Cold Drinks, Breads

        // Navigation Properties
        public List<Product> Products { get; set; } = new();
    }
}