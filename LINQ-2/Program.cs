

using LINQ_2;

public class MainClass
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        //var evenNumbers = numbers.Where(x => x % 2 == 0);
        IEnumerable<int> evenNumbers = 
            numbers.Where(x => x % 2 == 0); // construction (lazy loading)
    
        numbers.Add(10);
        numbers.Add(12);
        numbers.Remove(4);

        // [1]  ===>   2, 4, 6, 8
        // [2]  ===>   2, 6, 8, 10, 12
        foreach (var n in evenNumbers) // enumeration (immediate execution)
        {
            Console.Write($" {n}");
        }
        
        /*
         In this context, lazy loading means that the query (numbers.Where(x => x % 2 == 0)) 
         is not executed immediately when it is defined. Instead, 
         it is executed only when it is actually iterated over, such as in the foreach loop.

        Explanation:
        IEnumerable<int> evenNumbers = numbers.Where(x => x % 2 == 0);
        This only defines the query but does not execute it immediately.
        
        When new elements (10 and 12) are added to numbers, and 4 is removed, 
        the evenNumbers query is still valid because it depends on numbers dynamically.
        
        The actual filtering happens at the moment of iteration (foreach (var n in evenNumbers) { ... }).
         */
        //-----------------------
        
        // there are 3 ways for quering  !! //
        
        //1 : 
        List<int> newNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        
        var evenNumbersUsingExtensionWhere = 
            newNumbers.Where(x => x % 2 == 0);
        
        var evenNumbersUsingEnumerableWhereMethod =
            Enumerable.Where(newNumbers, x => x % 2 == 0);
        
        var evenNumbersUsingQuerySyntax = 
            from x in newNumbers
            where x % 2 == 0
            select x;
        
        evenNumbersUsingExtensionWhere.Print("Even Numbers Using Extension Where");
        evenNumbersUsingEnumerableWhereMethod.Print("Even Numbers Using Enumerable Where Method");
        evenNumbersUsingQuerySyntax.Print("Even Numbers Using Query Syntax");
    }
}