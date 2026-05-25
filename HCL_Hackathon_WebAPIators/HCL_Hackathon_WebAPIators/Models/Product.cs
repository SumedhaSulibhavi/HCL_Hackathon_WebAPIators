using System.Collections.Generic;

namespace HCL_Hackathon_WebAPIators.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; } // Precision handling configured in DbContext
        public int StockQuantity { get; set; }

        // Foreign Keys according to ERD layout maps
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public int PackagingId { get; set; }
        public Packaging? Packaging { get; set; }

        // Navigation Properties
        public List<OrderItem> OrderItems { get; set; } = new();
    }
}