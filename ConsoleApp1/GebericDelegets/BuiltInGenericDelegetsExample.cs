namespace ConsoleApp1.GebericDelegets;

public class BuiltInGenericDelegetsExample
{
    public static void FindEmlementsAccordingToStatement<T>(IEnumerable<T> numbers, Predicate<T> filter)
    {
        foreach (var item in numbers)
        {
            if (filter(item))
            {
                Console.WriteLine(item);
            }
        }
    }
}