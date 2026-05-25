using System.Collections.Generic;

namespace HCL_Hackathon_WebAPIators.Models
{
    public class Coupon
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public decimal DiscountValue { get; set; }
        public bool IsSummaryBased { get; set; } = false;

        // Navigation Properties
        public List<Order> Orders { get; set; } = new();
    }
}
