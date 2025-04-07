namespace ConsoleApp1.delegets;

public class Report
{
    public delegate bool IllegableSales(UserEmployee employee);

    public void ReportProcessor(List<UserEmployee> employees, string message, IllegableSales isIllegable)
    {
        Console.WriteLine(message);
        Console.WriteLine("--------------------------------------------");
        foreach (UserEmployee employee in employees)
        {
            if (isIllegable(employee))
            {
                Console.WriteLine($"{employee.Id} | {employee.Name} | {employee.TotalSales}");
            }
        }
    }
}