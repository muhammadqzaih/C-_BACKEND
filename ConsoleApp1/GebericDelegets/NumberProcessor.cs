namespace ConsoleApp1.GebericDelegets;

public class NumberProcessor
{
    public Func<int, int , int> Operation {get; set;}
    public Action<string> Logger { get; set; }
    public Predicate<int> Condition { get; set; }

    public NumberProcessor()
    {
        // Default behaviors
        Operation = (a, b) => a + b; // Default: Addition
        Logger = message => Console.WriteLine($"Log: {message}");
        Condition = num => num > 0; // Default: Check if number is positive
    }
    
    public int ExecuteOperation(int x, int y)
    {
        Logger($"Performing operation on {x} and {y}");
        return Operation(x, y);
    }

    public List<int> FilterNumbers(List<int> numbers)
    {
        return numbers.FindAll(Condition);
    }
}