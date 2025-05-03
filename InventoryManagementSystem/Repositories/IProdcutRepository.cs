using InventoryManagementSystem.Entities;

namespace InventoryManagementSystem
    .Repositories;

public interface IProdcutRepository
{
    Product? GetProduct(string productName);
    bool AddProduct(Product? product);
    ICollection<Product> GetAllProducts();
    bool RemoveProduct(string productName);
    bool IsProductInTheInventory(string productName);
    bool IsTheInventoryEmpty();
}