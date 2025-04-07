using InventoryManagementSystem.Common.Constants;

namespace InventoryManagementSystem.Common.ResultPattern.Constants;

public class Errors
{
    public class Product
    {
        public static readonly Error ProductNotFound =
            new("Error.ProductNotFound", "Product not found");

        public static readonly Error ProductAlreadyExists =
            new("Error.ProductAlreadyExists", "Product already exists");
    }

    public class Inventory
    {
        public static readonly Error InventoryEmpty =
            new("Error.InventoryEmpty", "Inventory Is Empty");
    }
}