namespace ConsoleApp1.delegets;

public class UserEmployee
{
    public string Name { get; set; }
    public string Id { get; set; }
    public int TotalSales { get; set; }

    public UserEmployee(string name, string id, int totalSales)
    {
        Name = name;
        Id = id;
        TotalSales = totalSales;
    }
}
