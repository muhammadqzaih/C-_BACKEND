using EF007.BasicSetup.Data;

class Program
{
    public static void Main(string[] args)
    {
        var context = new AppDbContext();
        // foreach (var product in context.Products)
        // {
        //     Console.WriteLine(product.Name);
        // }
        
        // test view : 
        foreach (var item in context.OrderWithDetailsView)
        {
            Console.WriteLine(item);
        }
    }
}