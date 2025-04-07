namespace LINQ.Implementations;

public static class ExtnensionProceduralVersion2
{
    public static IEnumerable<Employee> Filter(this IEnumerable<Employee> employees,
        Func<Employee, bool> predicate)
    {
        foreach (var employee in employees)
        {
            if (predicate(employee))
            {
                yield return employee;
            }
        }
    }
    
    public static void Print<T>(this IEnumerable<T> source, string title)
    {
        if (source == null)
            return;
        Console.WriteLine();
        Console.WriteLine("┌───────────────────────────────────────────────────────┐");
        Console.WriteLine($"│   {title.PadRight(52, ' ')}│");
        Console.WriteLine("└───────────────────────────────────────────────────────┘");
        Console.WriteLine();
        foreach (var item in source)
            Console.WriteLine(item);
    }
}