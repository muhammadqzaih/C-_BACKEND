namespace InventoryManagementSystem.Entities;

public class Product
{
    public decimal Price { get; set; }
    public string Name { get; set; }
    public int QuantityInStock { get; set; }

    public override string ToString()
    {
        return
            string.Format($"" +
                          $" {String.Concat(Name),-15}\t" +
                          $"{Price}\t" +
                          $"${QuantityInStock}");
    }
}