using InventoryManagementSystem.Common;
using InventoryManagementSystem.Entities;
using InventoryManagementSystem.Repositories;
using InventoryManagementSystem.Services;



namespace InventoryManagementSystem
{
    class Client
    {
        static void Main(string[] args)
        {
            string connString =
                @"Server=DESKTOP-KC6Q3HJ\SQLEXPRESS;Database=InventoryDB;Trusted_Connection=True;TrustServerCertificate=True;";

            IInventoryService inventoryService =
                new InventoryService(new ProductRepository(connString));

            // Fetching all products
            Console.WriteLine("Fetching all products...");
            Result<ICollection<Product>> allProductsResult = inventoryService.GetAllProducts();

            // Check if the result is successful
            if (allProductsResult.IsSuccess)
            {
                // If successful, print the products
                PrintProducts(allProductsResult.Value);
            }
            else
            {
                // If failure, print the error message
                Console.WriteLine($"Failed to fetch products: {allProductsResult.Error.ErrorMessage}");
            }
        }

        // Method to print products
        public static void PrintProducts(IEnumerable<Product> products)
        {
            if (products == null || !products.Any())
            {
                Console.WriteLine("No products available.");
                return;
            }

            foreach (var product in products)
            {
                Console.WriteLine($"Product: {product.Name}, Price: {product.Price}, Quantity: {product.QuantityInStock}");
            }
        }
       
    }
}