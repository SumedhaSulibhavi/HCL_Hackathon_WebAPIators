//using HCL_Hackathon_WebAPIators.Models;
//using Microsoft.EntityFrameworkCore;
//using System.Reflection.Emit;

//namespace HCL_Hackathon_WebAPIators.Data
//{
//    public class AppDbContext : DbContext
//    {
//        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
//        {
//        }

//        public DbSet<User> Users => Set<User>();
//        public DbSet<Brand> Brands => Set<Brand>();
//        public DbSet<Category> Categories => Set<Category>();
//        public DbSet<Packaging> Packagings => Set<Packaging>();
//        public DbSet<Product> Products => Set<Product>();
//        public DbSet<Coupon> Coupons => Set<Coupon>();
//        public DbSet<Order> Orders => Set<Order>();
//        public DbSet<OrderItem> OrderItems => Set<OrderItem>();

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);

//            // 1. Unique Constraints & Index Assertions from ERD
//            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique(); 
//            modelBuilder.Entity<Coupon>().HasIndex(c => c.Code).IsUnique();

//            // 2. Strict Decimal Currency Formats (Zero floating-point calculation drift)
//            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(10,2)");
//            modelBuilder.Entity<Coupon>().Property(c => c.DiscountValue).HasColumnType("decimal(10,2)");
//            modelBuilder.Entity<Order>().Property(o => o.TotalPrice).HasColumnType("decimal(10,2)");
//           modelBuilder.Entity<OrderItem>().Property(oi => oi.UnitPrice).HasColumnType("decimal(10,2)"); 

//            // 3. Performance Query Indexing on Foreign Keys
//            modelBuilder.Entity<Product>().HasIndex(p => p.BrandId);
//            modelBuilder.Entity<Product>().HasIndex(p => p.CategoryId);
//            modelBuilder.Entity<Product>().HasIndex(p => p.PackagingId);
//             modelBuilder.Entity<Order>().HasIndex(o => o.UserId);
//            modelBuilder.Entity<Order>().HasIndex(o => o.AppliedCouponId);
//             modelBuilder.Entity<OrderItem>().HasIndex(oi => oi.OrderId); 
//            modelBuilder.Entity<OrderItem>().HasIndex(oi => oi.ProductId);

//            // 4. Seeding Core Lookup Metadata Rows
//            modelBuilder.Entity<Brand>().HasData(
//                new Brand { Id = 1, Name = "Pizza Express Brand" },
//                new Brand { Id = 2, Name = "Beverage Craft Brand" }
//            );

//            modelBuilder.Entity<Category>().HasData(
//                new Category { Id = 1, Name = "Pizza" },
//                new Category { Id = 2, Name = "Drink" },
//                new Category { Id = 3, Name = "Bread" }
//            );

//            modelBuilder.Entity<Packaging>().HasData(
//                new Packaging { Id = 1, Type = "Cardboard Box" },
//                new Packaging { Id = 2, Type = "Aluminium Can" },
//                new Packaging { Id = 3, Type = "Paper Wrapper" }
//            );

//            // 5. Seeding Target Store Inventory Products
//            modelBuilder.Entity<Product>().HasData(
//                new Product { Id = 1, Name = "Margherita Feast Pizza", Price = 12.99m, StockQuantity = 50, BrandId = 1, CategoryId = 1, PackagingId = 1 },
//                new Product { Id = 2, Name = "Fiery Chicken Tikka Pizza", Price = 15.99m, StockQuantity = 35, BrandId = 1, CategoryId = 1, PackagingId = 1 },
//                new Product { Id = 3, Name = "Cheesy Garlic Sticks", Price = 5.49m, StockQuantity = 40, BrandId = 1, CategoryId = 3, PackagingId = 3 },
//                new Product { Id = 4, Name = "Ice Cold Cola Premium", Price = 2.49m, StockQuantity = 100, BrandId = 2, CategoryId = 2, PackagingId = 2 }
//            );

//            // 6. Seeding Coupons Core Maps
//            modelBuilder.Entity<Coupon>().HasData(
//                new Coupon { Id = 1, Code = "HCLPIZZA10", DiscountValue = 10.00m, IsSummaryBased = true },
//                new Coupon { Id = 2, Code = "CRISP5", DiscountValue = 5.00m, IsSummaryBased = false }
//            );

//            // 7. Seeding Demo Identity Accounts (Pre-hashed via BCrypt)
//            modelBuilder.Entity<User>().HasData(
//                new User
//                {
//                    Id = 1,
//                    Username = "Sanjana Admin",
//                    Email = "admin@pizza.com",
//                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"),
//                    Role = "Manager",
//                    LoyaltyPoints = 100
//                },
//                new User
//                {
//                    Id = 2,
//                    Username = "John Guest",
//                    Email = "john@customer.com",
//                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("User@123"),
//                    Role = "Customer",
//                    LoyaltyPoints = 25
//                }
//            );
//        }
//    }
//}

using HCL_Hackathon_WebAPIators.Models;
using Microsoft.EntityFrameworkCore;

namespace HCL_Hackathon_WebAPIators.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Brand> Brands => Set<Brand>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Packaging> Packagings => Set<Packaging>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Coupon> Coupons => Set<Coupon>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Unique Constraints & Index Assertions
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Coupon>().HasIndex(c => c.Code).IsUnique();

            // 2. Strict Decimal Currency Formats (Optimized for Indian Rupee Precision)
            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<Coupon>().Property(c => c.DiscountValue).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<Order>().Property(o => o.TotalPrice).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<OrderItem>().Property(oi => oi.UnitPrice).HasColumnType("decimal(10,2)");

            // 3. Performance Query Indexing on Foreign Keys
            modelBuilder.Entity<Product>().HasIndex(p => p.BrandId);
            modelBuilder.Entity<Product>().HasIndex(p => p.CategoryId);
            modelBuilder.Entity<Product>().HasIndex(p => p.PackagingId);
            modelBuilder.Entity<Order>().HasIndex(o => o.UserId);
            modelBuilder.Entity<Order>().HasIndex(o => o.AppliedCouponId);
            modelBuilder.Entity<OrderItem>().HasIndex(oi => oi.OrderId);
            modelBuilder.Entity<OrderItem>().HasIndex(oi => oi.ProductId);

            // ==========================================
            // 4. SEEDING METADATA LOOKUP TABLES
            // ==========================================

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Pizza" },
                new Category { Id = 2, Name = "Drink" },
                new Category { Id = 3, Name = "Bread" }
            );

            modelBuilder.Entity<Brand>().HasData(
                // Pizza Brands (1-5)
                new Brand { Id = 1, Name = "La Pino's India" },
                new Brand { Id = 2, Name = "Domino's Corner" },
                new Brand { Id = 3, Name = "Pizza Hut Premium" },
                new Brand { Id = 4, Name = "Mojo Pizza Co." },
                new Brand { Id = 5, Name = "Ovenstory Semifredo" },
                // Beverage Brands (6-10)
                new Brand { Id = 6, Name = "Coca-Cola India" },
                new Brand { Id = 7, Name = "PepsiCo Beverages" },
                new Brand { Id = 8, Name = "Hector Beverages (Paper Boat)" },
                new Brand { Id = 9, Name = "Amul Dairy Products" },
                new Brand { Id = 10, Name = "Bisleri International" },
                // Bread Brands (11-15)
                new Brand { Id = 11, Name = "Garlic Bread Masters" },
                new Brand { Id = 12, Name = "The Bakehouse Co." },
                new Brand { Id = 13, Name = "Britannia Foods" },
                new Brand { Id = 14, Name = "English Oven" },
                new Brand { Id = 15, Name = "Bonn Nutrients" }
            );

            modelBuilder.Entity<Packaging>().HasData(
                new Packaging { Id = 1, Type = "Eco-Friendly Cardboard Pizza Box" },
                new Packaging { Id = 2, Type = "Recyclable Aluminium Can 330ml" },
                new Packaging { Id = 3, Type = "PET Plastic Bottle 500ml" },
                new Packaging { Id = 4, Type = "Biodegradable Paper Food Wrap" },
                new Packaging { Id = 5, Type = "Glass Bottle Premium Premium" }
            );

            // ==========================================
            // 5. HIGH-FIDELITY INDIAN MARKET PRODUCT SEEDS
            // ==========================================

            // --- 20 PIZZA ITEMS (Category ID: 1, Pricing in INR ₹) ---
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Classic Margherita Pizza", Price = 249.00m, StockQuantity = 50, CategoryId = 1, BrandId = 1, PackagingId = 1 },
                new Product { Id = 2, Name = "Double Cheese Margherita", Price = 389.00m, StockQuantity = 45, CategoryId = 1, BrandId = 2, PackagingId = 1 },
                new Product { Id = 3, Name = "Fiery Paneer Tikka Pizza", Price = 429.00m, StockQuantity = 40, CategoryId = 1, BrandId = 1, PackagingId = 1 },
                new Product { Id = 4, Name = "Veggie Supreme Feast", Price = 499.00m, StockQuantity = 35, CategoryId = 1, BrandId = 3, PackagingId = 1 },
                new Product { Id = 5, Name = "Chicken Dominator Special", Price = 599.00m, StockQuantity = 30, CategoryId = 1, BrandId = 2, PackagingId = 1 },
                new Product { Id = 6, Name = "Spicy Triple Chicken Pizza", Price = 649.00m, StockQuantity = 25, CategoryId = 1, BrandId = 4, PackagingId = 1 },
                new Product { Id = 7, Name = "Capsicum & Sweet Corn Classic", Price = 299.00m, StockQuantity = 60, CategoryId = 1, BrandId = 1, PackagingId = 1 },
                new Product { Id = 8, Name = "4-Cheese Pizza Blast", Price = 519.00m, StockQuantity = 20, CategoryId = 1, BrandId = 5, PackagingId = 1 },
                new Product { Id = 9, Name = "Indi Tandoori Paneer Premium", Price = 459.00m, StockQuantity = 38, CategoryId = 1, BrandId = 2, PackagingId = 1 },
                new Product { Id = 10, Name = "Pepper Chicken Exotic Pizza", Price = 579.00m, StockQuantity = 32, CategoryId = 1, BrandId = 3, PackagingId = 1 },
                new Product { Id = 11, Name = "Farmvilla Garden Special", Price = 419.00m, StockQuantity = 40, CategoryId = 1, BrandId = 4, PackagingId = 1 },
                new Product { Id = 12, Name = "Tikka Masala Chicken Feast", Price = 589.00m, StockQuantity = 28, CategoryId = 1, BrandId = 5, PackagingId = 1 },
                new Product { Id = 13, Name = "Cheesy Mushroom Delight", Price = 379.00m, StockQuantity = 30, CategoryId = 1, BrandId = 1, PackagingId = 1 },
                new Product { Id = 14, Name = "Fiery Jalapeno & Paprika Spicy", Price = 399.00m, StockQuantity = 35, CategoryId = 1, BrandId = 3, PackagingId = 1 },
                new Product { Id = 15, Name = "Chicken Keema Makhani", Price = 619.00m, StockQuantity = 22, CategoryId = 1, BrandId = 2, PackagingId = 1 },
                new Product { Id = 16, Name = "Classic Onion & Tomato Single", Price = 199.00m, StockQuantity = 70, CategoryId = 1, BrandId = 1, PackagingId = 1 },
                new Product { Id = 17, Name = "Peri Peri Veggie Blast", Price = 439.00m, StockQuantity = 45, CategoryId = 1, BrandId = 4, PackagingId = 1 },
                new Product { Id = 18, Name = "Malai Tikka Chicken Supreme", Price = 629.00m, StockQuantity = 24, CategoryId = 1, BrandId = 5, PackagingId = 1 },
                new Product { Id = 19, Name = "Exotic Italian Garden Pizza", Price = 489.00m, StockQuantity = 18, CategoryId = 1, BrandId = 3, PackagingId = 1 },
                new Product { Id = 20, Name = "Ultimate Non-Veg Overload", Price = 699.00m, StockQuantity = 15, CategoryId = 1, BrandId = 2, PackagingId = 1 }
            );

            // --- 15 BEVERAGE ITEMS (Category ID: 2, Pricing in INR ₹) ---
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 21, Name = "Coca-Cola Aerated Can", Price = 40.00m, StockQuantity = 150, CategoryId = 2, BrandId = 6, PackagingId = 2 },
                new Product { Id = 22, Name = "Diet Coke Zero Sugar", Price = 45.00m, StockQuantity = 100, CategoryId = 2, BrandId = 6, PackagingId = 2 },
                new Product { Id = 23, Name = "Thums Up Strong Spice Can", Price = 40.00m, StockQuantity = 200, CategoryId = 2, BrandId = 6, PackagingId = 2 },
                new Product { Id = 24, Name = "Pepsi Fizz Cola Can", Price = 38.00m, StockQuantity = 180, CategoryId = 2, BrandId = 7, PackagingId = 2 },
                new Product { Id = 25, Name = "Mirinda Orange Fruity Can", Price = 38.00m, StockQuantity = 120, CategoryId = 2, BrandId = 7, PackagingId = 2 },
                new Product { Id = 26, Name = "Sprite Lime Refresher Can", Price = 40.00m, StockQuantity = 140, CategoryId = 2, BrandId = 6, PackagingId = 2 },
                new Product { Id = 27, Name = "Paper Boat Mango Juice Premium", Price = 50.00m, StockQuantity = 90, CategoryId = 2, BrandId = 8, PackagingId = 4 },
                new Product { Id = 28, Name = "Paper Boat Aam Panna Tangy", Price = 50.00m, StockQuantity = 85, CategoryId = 2, BrandId = 8, PackagingId = 4 },
                new Product { Id = 29, Name = "Amul Kool Premium Kesar Almond", Price = 40.00m, StockQuantity = 110, CategoryId = 2, BrandId = 9, PackagingId = 5 },
                new Product { Id = 30, Name = "Amul Rose Milk Shake Bottle", Price = 35.00m, StockQuantity = 95, CategoryId = 2, BrandId = 9, PackagingId = 5 },
                new Product { Id = 31, Name = "Amul Buttermilk Masti Spiced", Price = 20.00m, StockQuantity = 300, CategoryId = 2, BrandId = 9, PackagingId = 4 },
                new Product { Id = 32, Name = "Bisleri Mineral Drinking Water", Price = 20.00m, StockQuantity = 500, CategoryId = 2, BrandId = 10, PackagingId = 3 },
                new Product { Id = 33, Name = "Vedica Himalayan Spring Glass", Price = 60.00m, StockQuantity = 60, CategoryId = 2, BrandId = 10, PackagingId = 5 },
                new Product { Id = 34, Name = "7Up Lemon Clear Refresh Bottle", Price = 35.00m, StockQuantity = 130, CategoryId = 2, BrandId = 7, PackagingId = 3 },
                new Product { Id = 35, Name = "Minute Maid Pulpy Orange Pack", Price = 45.00m, StockQuantity = 100, CategoryId = 2, BrandId = 6, PackagingId = 3 }
            );

            // --- 20 BREAD ITEMS (Category ID: 3, Pricing in INR ₹) ---
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 36, Name = "Classic Cheesy Garlic Breadsticks", Price = 149.00m, StockQuantity = 80, CategoryId = 3, BrandId = 11, PackagingId = 4 },
                new Product { Id = 37, Name = "Stuffed Paneer Garlic Breadsticks", Price = 179.00m, StockQuantity = 65, CategoryId = 3, BrandId = 11, PackagingId = 4 },
                new Product { Id = 38, Name = "Gourmet Cheese & Jalapeno Bread", Price = 189.00m, StockQuantity = 40, CategoryId = 3, BrandId = 12, PackagingId = 4 },
                new Product { Id = 39, Name = "Britannia Premium Fruit Bread Loaf", Price = 50.00m, StockQuantity = 120, CategoryId = 3, BrandId = 13, PackagingId = 4 },
                new Product { Id = 40, Name = "Britannia 100-Percent Whole Wheat", Price = 45.00m, StockQuantity = 140, CategoryId = 3, BrandId = 13, PackagingId = 4 },
                new Product { Id = 41, Name = "English Oven Gourmet Sandwich Loaf", Price = 55.00m, StockQuantity = 100, CategoryId = 3, BrandId = 14, PackagingId = 4 },
                new Product { Id = 42, Name = "English Oven Atta Whole Wheat", Price = 50.00m, StockQuantity = 110, CategoryId = 3, BrandId = 14, PackagingId = 4 },
                new Product { Id = 43, Name = "Bonn Atta High Fiber Pack", Price = 42.00m, StockQuantity = 150, CategoryId = 3, BrandId = 15, PackagingId = 4 },
                new Product { Id = 44, Name = "Spicy Chicken Kheema Stuffed Bread", Price = 219.00m, StockQuantity = 35, CategoryId = 3, BrandId = 11, PackagingId = 4 },
                new Product { Id = 45, Name = "Corn & Kernel Cheese Stuffed Bread", Price = 169.00m, StockQuantity = 50, CategoryId = 3, BrandId = 11, PackagingId = 4 },
                new Product { Id = 46, Name = "French Sourdough Artisanal Baguette", Price = 129.00m, StockQuantity = 25, CategoryId = 3, BrandId = 12, PackagingId = 4 },
                new Product { Id = 47, Name = "Italian Herbs Focaccia Loaf", Price = 159.00m, StockQuantity = 30, CategoryId = 3, BrandId = 12, PackagingId = 4 },
                new Product { Id = 48, Name = "Multi-Grain Fitness Rich Loaf", Price = 65.00m, StockQuantity = 85, CategoryId = 3, BrandId = 14, PackagingId = 4 },
                new Product { Id = 49, Name = "Sweet Honey & Oats Breakfast Loaf", Price = 70.00m, StockQuantity = 75, CategoryId = 3, BrandId = 14, PackagingId = 4 },
                new Product { Id = 50, Name = "Bonn Premium White Milky Loaf", Price = 38.00m, StockQuantity = 200, CategoryId = 3, BrandId = 15, PackagingId = 4 },
                new Product { Id = 51, Name = "Garlic Pull-Apart Cheese Bomb Loaf", Price = 199.00m, StockQuantity = 30, CategoryId = 3, BrandId = 12, PackagingId = 4 },
                new Product { Id = 52, Name = "Britannia Brown Bread Wheat Loaf", Price = 48.00m, StockQuantity = 130, CategoryId = 3, BrandId = 13, PackagingId = 4 },
                new Product { Id = 53, Name = "Cheese Stuffed Garlic Calzone Bread", Price = 159.00m, StockQuantity = 45, CategoryId = 3, BrandId = 11, PackagingId = 4 },
                new Product { Id = 54, Name = "Exotic Olive & Oregano Loaf", Price = 149.00m, StockQuantity = 20, CategoryId = 3, BrandId = 12, PackagingId = 4 },
                new Product { Id = 55, Name = "English Oven Premium Pav Bun Pack", Price = 40.00m, StockQuantity = 180, CategoryId = 3, BrandId = 14, PackagingId = 4 }
            );

            // ==========================================
            // 6. SEEDING COUPONS & ACCOUNTS
            // ==========================================

            modelBuilder.Entity<Coupon>().HasData(
                new Coupon { Id = 1, Code = "HCLPIZZA10", DiscountValue = 10.00m, IsSummaryBased = true },
                new Coupon { Id = 2, Code = "CRISP5", DiscountValue = 5.00m, IsSummaryBased = false }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "Sanjana Admin", Email = "admin@pizza.com", PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"), Role = "Manager", LoyaltyPoints = 100 },
                new User { Id = 2, Username = "John Guest", Email = "john@customer.com", PasswordHash = BCrypt.Net.BCrypt.HashPassword("User@123"), Role = "Customer", LoyaltyPoints = 25 }
            );
        }
    }
}