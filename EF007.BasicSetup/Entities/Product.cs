namespace EF007.BasicSetup.Entities;

public class Product
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public decimal UnitPrice { get; set; }
    
    public string description { get; set; }
}

public class Order
{
    public int Id { get; set; }
    
    public string CustomerEmail { get; set; }
    
    public DateTime OrderDate { get; set; }
    
    public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    
}

public class OrderDetail
{
    public int Id { get; set; }
    
    public int OrderId { get; set; }
    
    public int ProductId { get; set; }
    
    public int Quantity { get; set; }
    
    public decimal UnitPrice { get; set; }
    
    public Order Order { get; set; }
    
    public Product Product { get; set; }
}