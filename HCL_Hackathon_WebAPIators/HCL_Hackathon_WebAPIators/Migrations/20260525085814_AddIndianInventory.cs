using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HCL_Hackathon_WebAPIators.Migrations
{
    /// <inheritdoc />
    public partial class AddIndianInventory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "La Pino's India");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Domino's Corner");

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "Pizza Hut Premium" },
                    { 4, "Mojo Pizza Co." },
                    { 5, "Ovenstory Semifredo" },
                    { 6, "Coca-Cola India" },
                    { 7, "PepsiCo Beverages" },
                    { 8, "Hector Beverages (Paper Boat)" },
                    { 9, "Amul Dairy Products" },
                    { 10, "Bisleri International" },
                    { 11, "Garlic Bread Masters" },
                    { 12, "The Bakehouse Co." },
                    { 13, "Britannia Foods" },
                    { 14, "English Oven" },
                    { 15, "Bonn Nutrients" }
                });

            migrationBuilder.UpdateData(
                table: "Packagings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: "Eco-Friendly Cardboard Pizza Box");

            migrationBuilder.UpdateData(
                table: "Packagings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: "Recyclable Aluminium Can 330ml");

            migrationBuilder.UpdateData(
                table: "Packagings",
                keyColumn: "Id",
                keyValue: 3,
                column: "Type",
                value: "PET Plastic Bottle 500ml");

            migrationBuilder.InsertData(
                table: "Packagings",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 4, "Biodegradable Paper Food Wrap" },
                    { 5, "Glass Bottle Premium Premium" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Price" },
                values: new object[] { "Classic Margherita Pizza", 249.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BrandId", "Name", "Price", "StockQuantity" },
                values: new object[] { 2, "Double Cheese Margherita", 389.00m, 45 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Name", "PackagingId", "Price" },
                values: new object[] { 1, "Fiery Paneer Tikka Pizza", 1, 429.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BrandId", "CategoryId", "Name", "PackagingId", "Price", "StockQuantity" },
                values: new object[] { 3, 1, "Veggie Supreme Feast", 1, 499.00m, 35 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "Name", "PackagingId", "Price", "StockQuantity" },
                values: new object[,]
                {
                    { 5, 2, 1, "Chicken Dominator Special", 1, 599.00m, 30 },
                    { 7, 1, 1, "Capsicum & Sweet Corn Classic", 1, 299.00m, 60 },
                    { 9, 2, 1, "Indi Tandoori Paneer Premium", 1, 459.00m, 38 },
                    { 13, 1, 1, "Cheesy Mushroom Delight", 1, 379.00m, 30 },
                    { 15, 2, 1, "Chicken Keema Makhani", 1, 619.00m, 22 },
                    { 16, 1, 1, "Classic Onion & Tomato Single", 1, 199.00m, 70 },
                    { 20, 2, 1, "Ultimate Non-Veg Overload", 1, 699.00m, 15 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$OfA1PLLf6/9PdAAtGCImOOYS1ZZ3E6A6i2UqAws2.Ugsk4D1ERclK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$diqJ3YjKcFsCV5/cRx1chehp74tT5.5g4H916uczjkF3RaOWy0kQW");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "Name", "PackagingId", "Price", "StockQuantity" },
                values: new object[,]
                {
                    { 6, 4, 1, "Spicy Triple Chicken Pizza", 1, 649.00m, 25 },
                    { 8, 5, 1, "4-Cheese Pizza Blast", 1, 519.00m, 20 },
                    { 10, 3, 1, "Pepper Chicken Exotic Pizza", 1, 579.00m, 32 },
                    { 11, 4, 1, "Farmvilla Garden Special", 1, 419.00m, 40 },
                    { 12, 5, 1, "Tikka Masala Chicken Feast", 1, 589.00m, 28 },
                    { 14, 3, 1, "Fiery Jalapeno & Paprika Spicy", 1, 399.00m, 35 },
                    { 17, 4, 1, "Peri Peri Veggie Blast", 1, 439.00m, 45 },
                    { 18, 5, 1, "Malai Tikka Chicken Supreme", 1, 629.00m, 24 },
                    { 19, 3, 1, "Exotic Italian Garden Pizza", 1, 489.00m, 18 },
                    { 21, 6, 2, "Coca-Cola Aerated Can", 2, 40.00m, 150 },
                    { 22, 6, 2, "Diet Coke Zero Sugar", 2, 45.00m, 100 },
                    { 23, 6, 2, "Thums Up Strong Spice Can", 2, 40.00m, 200 },
                    { 24, 7, 2, "Pepsi Fizz Cola Can", 2, 38.00m, 180 },
                    { 25, 7, 2, "Mirinda Orange Fruity Can", 2, 38.00m, 120 },
                    { 26, 6, 2, "Sprite Lime Refresher Can", 2, 40.00m, 140 },
                    { 27, 8, 2, "Paper Boat Mango Juice Premium", 4, 50.00m, 90 },
                    { 28, 8, 2, "Paper Boat Aam Panna Tangy", 4, 50.00m, 85 },
                    { 29, 9, 2, "Amul Kool Premium Kesar Almond", 5, 40.00m, 110 },
                    { 30, 9, 2, "Amul Rose Milk Shake Bottle", 5, 35.00m, 95 },
                    { 31, 9, 2, "Amul Buttermilk Masti Spiced", 4, 20.00m, 300 },
                    { 32, 10, 2, "Bisleri Mineral Drinking Water", 3, 20.00m, 500 },
                    { 33, 10, 2, "Vedica Himalayan Spring Glass", 5, 60.00m, 60 },
                    { 34, 7, 2, "7Up Lemon Clear Refresh Bottle", 3, 35.00m, 130 },
                    { 35, 6, 2, "Minute Maid Pulpy Orange Pack", 3, 45.00m, 100 },
                    { 36, 11, 3, "Classic Cheesy Garlic Breadsticks", 4, 149.00m, 80 },
                    { 37, 11, 3, "Stuffed Paneer Garlic Breadsticks", 4, 179.00m, 65 },
                    { 38, 12, 3, "Gourmet Cheese & Jalapeno Bread", 4, 189.00m, 40 },
                    { 39, 13, 3, "Britannia Premium Fruit Bread Loaf", 4, 50.00m, 120 },
                    { 40, 13, 3, "Britannia 100-Percent Whole Wheat", 4, 45.00m, 140 },
                    { 41, 14, 3, "English Oven Gourmet Sandwich Loaf", 4, 55.00m, 100 },
                    { 42, 14, 3, "English Oven Atta Whole Wheat", 4, 50.00m, 110 },
                    { 43, 15, 3, "Bonn Atta High Fiber Pack", 4, 42.00m, 150 },
                    { 44, 11, 3, "Spicy Chicken Kheema Stuffed Bread", 4, 219.00m, 35 },
                    { 45, 11, 3, "Corn & Kernel Cheese Stuffed Bread", 4, 169.00m, 50 },
                    { 46, 12, 3, "French Sourdough Artisanal Baguette", 4, 129.00m, 25 },
                    { 47, 12, 3, "Italian Herbs Focaccia Loaf", 4, 159.00m, 30 },
                    { 48, 14, 3, "Multi-Grain Fitness Rich Loaf", 4, 65.00m, 85 },
                    { 49, 14, 3, "Sweet Honey & Oats Breakfast Loaf", 4, 70.00m, 75 },
                    { 50, 15, 3, "Bonn Premium White Milky Loaf", 4, 38.00m, 200 },
                    { 51, 12, 3, "Garlic Pull-Apart Cheese Bomb Loaf", 4, 199.00m, 30 },
                    { 52, 13, 3, "Britannia Brown Bread Wheat Loaf", 4, 48.00m, 130 },
                    { 53, 11, 3, "Cheese Stuffed Garlic Calzone Bread", 4, 159.00m, 45 },
                    { 54, 12, 3, "Exotic Olive & Oregano Loaf", 4, 149.00m, 20 },
                    { 55, 14, 3, "English Oven Premium Pav Bun Pack", 4, 40.00m, 180 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Packagings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Packagings",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Pizza Express Brand");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Beverage Craft Brand");

            migrationBuilder.UpdateData(
                table: "Packagings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: "Cardboard Box");

            migrationBuilder.UpdateData(
                table: "Packagings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: "Aluminium Can");

            migrationBuilder.UpdateData(
                table: "Packagings",
                keyColumn: "Id",
                keyValue: 3,
                column: "Type",
                value: "Paper Wrapper");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Price" },
                values: new object[] { "Margherita Feast Pizza", 12.99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BrandId", "Name", "Price", "StockQuantity" },
                values: new object[] { 1, "Fiery Chicken Tikka Pizza", 15.99m, 35 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Name", "PackagingId", "Price" },
                values: new object[] { 3, "Cheesy Garlic Sticks", 3, 5.49m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BrandId", "CategoryId", "Name", "PackagingId", "Price", "StockQuantity" },
                values: new object[] { 2, 2, "Ice Cold Cola Premium", 2, 2.49m, 100 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$3hMy4flqWu1I9R/5AgRS/ux4P4kG9zNwlhWhaAL5JbecvDAEvehvK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$JYZdgKe/Oiv9NLBd6vkMAuyF0CuBtzXsfycq3NmMe3IOTWVs8Betu");
        }
    }
}
