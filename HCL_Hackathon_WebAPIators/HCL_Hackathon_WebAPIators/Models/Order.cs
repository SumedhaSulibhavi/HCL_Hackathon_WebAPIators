using System;
using System.Collections.Generic;

namespace HCL_Hackathon_WebAPIators.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public decimal TotalPrice { get; set; }
        public int PointsEarned { get; set; }
        public string Status { get; set; } = "Pending"; // Status states: Pending, Confirmed, Preparing, OutForDelivery, Delivered, Cancelled

        // Relational Configuration mappings from ERD
        public int UserId { get; set; } // Foreign Key marked in ERD
        public User? User { get; set; }

        public int? AppliedCouponId { get; set; } // Nullable Foreign Key reference from ERD
        public Coupon? AppliedCoupon { get; set; }

        // Navigation Properties
        public List<OrderItem> OrderItems { get; set; } = new();
    }
}