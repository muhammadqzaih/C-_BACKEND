using LINQ_5.Employee;

public class MainClass
{
    static void Main(string[] args)
    {
        RunGroupedBy();
        RunToLookUp();
    }

    /**
     In LINQ, both GroupBy and ToLookup are used for grouping data, but they differ in execution and behavior.
     GroupBy returns an IEnumerable<IGrouping<TKey, TElement>> and uses deferred execution, meaning it processes data only when iterated over,
     making it suitable for one-time use. On the other hand, ToLookup returns an ILookup<TKey, TElement> and uses immediate execution,
     storing the grouped data for efficient repeated lookups. Unlike GroupBy, ToLookup ensures that missing keys return an empty collection instead of
     throwing an error. Additionally, ToLookup is immutable, while GroupBy generates a new collection on each iteration.
      Generally, GroupBy is preferable when working with data only once, whereas ToLookup is better for frequent key-based lookups due to its optimized
     */
    private static void RunToLookUp()
    {
        Console.WriteLine("---------------------------- Using To Look Up: ----------------------------");
        var employees = Repository.LoadEmployees();
        var employeesGroupedByDepartment =
            employees.ToLookup(e => e.Department);
        foreach (var group in employeesGroupedByDepartment)
        {
            var department = group.Key;
            group.Print($"Employees for department:{department}");
        }
    }

    private static void RunGroupedBy()
    {
        var employees = Repository.LoadEmployees();
        var employeesGroupedByDepartment =
            employees.GroupBy(e => e.Department);
        foreach (var group in employeesGroupedByDepartment)
        {
            var department = group.Key;
            group.Print($"Employees for department:{department}");
        }
    }
}