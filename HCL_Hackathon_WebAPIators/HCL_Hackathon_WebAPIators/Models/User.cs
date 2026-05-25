using System.Collections.Generic;

namespace HCL_Hackathon_WebAPIators.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty; // Marked as Unique index constraint in ERD
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = "Customer"; // Roles permitted: Customer, Manager
        public int LoyaltyPoints { get; set; } = 0;

        // Navigation Properties
        public List<Order> Orders { get; set; } = new();
    }
}