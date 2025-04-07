using InventoryManagementSystem.Common;
using InventoryManagementSystem.Entities;
using InventoryManagementSystem.Helpers;

namespace InventoryManagementSystem
    .Services;

public interface IInventoryService
{
    public Result<ICollection<Product>> GetAllProducts();
    public Result<bool> AddProduct(Product? product);
    public Result<bool> RemoveProduct(string productName);
    public Result<Product?> GetProductByProductName(string productName);
}   