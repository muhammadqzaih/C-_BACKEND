using InventoryManagementSystem.Entities;

namespace InventoryManagementSystem.Common.Extensions;

public static class ProductExtensions
{
    public static void PrintProducts(this ICollection<Product>? products)
    {
        if (products == null || products.Count == 0)
        {
            Console.WriteLine("No products available.");
            return;
        }

        Console.WriteLine("Product List:");
        foreach (var product in products)
        {
            Console.WriteLine(
                $"Name: {product.Name}, " +
                $"Price: {product.Price}, " +
                $"Stock: {product.QuantityInStock}");
        }
    }
}