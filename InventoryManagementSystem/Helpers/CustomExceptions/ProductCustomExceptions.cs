namespace InventoryManagementSystem
          .Helpers
          .CustomExceptions;

public static class ProductCustomExceptions
{
    public class ProductNotFoundException(string productName)
        : Exception($"Product '{productName}' was not found in the inventory.");

    public class ProductAlreadyExistsException(string productName)
        : Exception($"Product '{productName}' already exists in the inventory.");
    
    public class InventoryEmptyException() 
        : Exception("The inventory is empty.");
    
    public class InsufficientStockException(string productName, int available, int requested)
        : Exception($"Cannot remove {requested} of '{productName}'. Only {available} available.");
}