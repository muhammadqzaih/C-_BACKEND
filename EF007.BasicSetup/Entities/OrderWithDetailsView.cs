namespace EF007.BasicSetup.Entities;

public class OrderWithDetailsView
{
    public int OrderId { get; set; }
    
    public DateTime OrderDate { get; set; }
    
    public string CustomerEmail { get; set; }
    
    public int ProductId { get; set; }
    
    public string ProductName { get; set; }
    
    public int Quantity { get; set; }
    
    public decimal UnitPrice { get; set; }

    public override string ToString()
    {
        return $"OrderId: {OrderId}, OrderDate: {OrderDate}, CustomerEmail: {CustomerEmail}, " +
            $"ProductId: {ProductId}, ProductName: {ProductName}, Quantity: {Quantity}, UnitPrice: {UnitPrice}";
    
    }
}