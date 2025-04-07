using InventoryManagementSystem.Common;
using InventoryManagementSystem.Common.Constants;
using InventoryManagementSystem.Common.ResultPattern.Constants;
using InventoryManagementSystem.Entities;
using InventoryManagementSystem.Helpers;
using InventoryManagementSystem.Helpers.CustomExceptions;
using InventoryManagementSystem.Repositories;

namespace InventoryManagementSystem.Services;

public class InventoryService : IInventoryService
{
    private readonly IProdcutRepository _prodcutRepository;

    public InventoryService(IProdcutRepository prodcutRepository)
    {
        _prodcutRepository = prodcutRepository;
    }


    public Result<ICollection<Product>> GetAllProducts()
    {
        var inventoryEmpty = _prodcutRepository.IsTheInventoryEmpty();
        if (inventoryEmpty)
        {
            return Result<ICollection<Product>>.Failure(Errors.Inventory.InventoryEmpty);
        }

        ICollection<Product> products = _prodcutRepository.GetAllProducts();
        return Result<ICollection<Product>>.Success(products);
    }


    public Result<bool> AddProduct(Product? product)
    {
        if (product == null)
        {
            return Result<bool>.Failure(Error.NullValue);
        }

        var productName = product.Name;
        var productExit = IsProductExistInTheInventory(productName);

        if (productExit.IsFailure)
        {
            return Result<bool>.Failure(Errors.Product.ProductAlreadyExists);
        }

        if (productExit.Value)
        {
            return Result<bool>.Failure(Errors.Product.ProductAlreadyExists);
        }

        var result = _prodcutRepository.AddProduct(product);
        return result
            ? Result<bool>.Success(true)
            : Result<bool>.Failure(Error.NotExpected);
    }

    public Result<bool> RemoveProduct(string productName)
    {
        var productExit = IsProductExistInTheInventory(productName);
        if (productExit.IsFailure)
        {
            return Result<bool>.Failure(Error.NullValue);
        }

        if (!productExit.Value)
        {
            return Result<bool>.Failure(Errors.Product.ProductNotFound);
        }

        var result = _prodcutRepository.RemoveProduct(productName);

        return result
            ? Result<bool>.Success(true)
            : Result<bool>.Failure(Error.NotExpected);
    }


    public Result<Product?> GetProductByProductName(string productName)
    {
        var productExistResult = IsProductExistInTheInventory(productName);

        if (productExistResult.IsFailure)
        {
            return Result<Product?>.Failure(productExistResult.Error);
        }

        if (!productExistResult.Value)
        {
            return Result<Product?>.Failure(Errors.Product.ProductNotFound);
        }

        var product = _prodcutRepository.GetProduct(productName);
        return Result<Product?>.Success(product);
    }

    private Result<bool> IsProductExistInTheInventory(string productName)
    {
        if (string.IsNullOrWhiteSpace(productName))
        {
            return Result<bool>.Failure(Error.NullValue);
        }

        var exists = _prodcutRepository.IsProductInTheInventory(productName);
        return Result<bool>.Success(exists);
    }
}