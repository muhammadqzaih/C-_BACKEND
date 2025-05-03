public class MainClass
{
    static void Main(string[] args)
    {
        RunAny();
        RunAll();
        RunContains();
    }

    private static void RunContains()
    {
        Console.WriteLine();
        Console.WriteLine("++++++++++++++");
        Console.WriteLine("Run Contain()");
        Console.WriteLine("++++++++++++++");
        Console.WriteLine();
        var employees = Repository.LoadEmployees();


        // if any employee contains 'ee' in his/her name

        var e1 = employees.ToArray()[0];
        var result1 = employees.Contains(e1);
        Console.WriteLine($"find if any employee contains " +
                          $"'{e1.Email}' in his/her name result: {result1}");

        var e2 = new Employee { Email = "Cole.Cochran02@example.com" };
        var result2 = employees.Contains(e2);
        Console.WriteLine($"find if any employee contains " +
                          $"'{e2.Email}' in his/her name result: {result2}");
    }

    private static void RunAll()
    {
        Console.WriteLine();
        Console.WriteLine("+++++++++");
        Console.WriteLine("Run All()");
        Console.WriteLine("+++++++++");
        Console.WriteLine();
        var employees = Repository.LoadEmployees();

        // if all employees have email defined
        var result1 = employees.All(e => !string.IsNullOrWhiteSpace(e.Email));
        Console.WriteLine($"All employees have email result: {result1} ");

        // if all employees have at least 1 skill
        var result2 = employees.All(e => e.Skills.Count >= 1);
        Console.WriteLine($"if all employees have at least 1 skills: {result2} ");
    }

    private static void RunAny()
    {
        Console.WriteLine();
        Console.WriteLine("+++++++++");
        Console.WriteLine("Run Any()");
        Console.WriteLine("+++++++++");
        Console.WriteLine();
        
        var employees = Repository.LoadEmployees();

        // if any employee name starts with some sequence of letter
        var input = "POPO";
        var result = employees.Any(e => e.Name.StartsWith(input, StringComparison.OrdinalIgnoreCase));
        Console.WriteLine($" if any employee name starts with some sequence of letter : {result}");

        // if any employee employee salary less tham 1000
        var result2 = employees.Any(e => e.Salary >= 1000);
        Console.WriteLine($"if any employee salary greater than 10000: {result2}");

        // if any employee with skills less tham 1000
        var result3 = employees.Any(e => e.Skills.Count < 1000);
        Console.WriteLine($"if any employee skills greater than 10000: {result3}");
    }
}