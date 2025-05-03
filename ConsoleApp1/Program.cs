using System.Diagnostics;
using ConsoleApp1;
using ConsoleApp1.delegets;
using ConsoleApp1.Events;
using ConsoleApp1.GebericDelegets;
using ConsoleApp1.IndexerExample;
using ConsoleApp1.MethodeExtensionExample;

public class Program
{
    static void Main(string[] args)
    {
        // this first comment
        int number = 0;
        Console.WriteLine(number);
        string str = "my name is muhammad qizh";
        Console.WriteLine(str);

        // string is a reference type !! int is a value type

        // concatenation in string : 
        string str1 = "my name is ";
        string str2 = "muhammad qzih";

        string str3 = str1 + str2;
        Console.WriteLine(str3);

        // we can make concatenation using interpolation : 
        string str4 = $"{str1} {str2}";
        Console.WriteLine(str4);

        // -------------------------------------------------------------
        Console.WriteLine("--------------------------------------------");


        //var vs dynamic : 
        // var : it take  any value sring or int .... , but ! we can not change the value type after make initalization! 
        // example : 
        var name = "muhammad";
        // name = 1; error !! 

        //full example :
        var firstName = "muhammad";
        var lastName = "qzih";
        var salary = 20000;
        Console.WriteLine($"{firstName}");
        Console.WriteLine($"{lastName}");
        Console.WriteLine($"{salary}");

        // dynamic : we can change the value type after inilization !!  
        dynamic age = 21;
        age = "age 21";
        Console.WriteLine(age);


        // arrays : 
        int[] freinds =
        {
            1, 2, 3, 4, 5, 6
        };

        //-----------------------

        string str_1 = null;
        str_1 = str_1 ?? "muhamasdasdmad";
        Console.WriteLine(str_1);

        str_1 = str_1 ?? "qzih";
        Console.WriteLine(str_1);


        string str_2 = null;
        var str_3 = str_2
            ?.ToUpper(); // this will give an null refrence Exception !! we should give it  ? (null condition).

        //-------------------------------------------
        // casting and type conversion: 
        // Implicit converion : 
        int number_1 = 10;
        long number_2 = number_1;

        // there is no implicit converion
        //long number_1 = 10;
        //int number_2 = number_1;


        // Explicit converion: 
        long number_3 = 10;
        if (number_3 <= Int32.MaxValue)
        {
            int nl = (int)number_3;
        }

        // another example on Explicit converion : 
        double number_4 = 2.10;
        int number_5 = (int)number_4;

        //--------------------------

        // Boxing vs Unboxing : 
        // Boxing : convert from value to refrence  ! 
        // Unboxing : convert form reference to value ! 

        int number_6 = 10;
        Object obj;
        obj = number_6; // Boxing

        int number_7 = (int)obj; // Unboxing

        //--------------------------
        // parsing string to int

        // we can use  TryParse : 

        string stringNumber = "9999";
        if (int.TryParse(stringNumber, out int numberParsedFromString))
        {
            Console.WriteLine(numberParsedFromString);
        }
        else
        {
            Console.WriteLine("Invalid number provided or does not fit Integer!");
        }
        // we can use another  choince (convert class ! ) Convert.toInt .. toDouble.... !! 

        // -- OOP : 

        Employee employee = new Employee();
        employee.fName = "muhammad";
        employee.lName = "qzih";
        employee.Id = "12027705";
        employee.lAddress = "nablus";
        employee.printInfo();

        Console.WriteLine(Employee.TAX);
        //------------------------
        Console.WriteLine(isEven(6));
        //------------------------------
        //-- indexers : 
        IpGenerator ipGenerator = new IpGenerator("127.123.123.111");
        Console.WriteLine(ipGenerator[0]);
        Console.WriteLine(ipGenerator[1]);
        Console.WriteLine(ipGenerator[2]);


        //--------------------
        // delegets example : 

        var usersEmployees = new List<UserEmployee>
        {
            new UserEmployee("Alice Johnson", "E001", 5000),
            new UserEmployee("Bob Smith", "E002", 4200),
            new UserEmployee("Charlie Brown", "E003", 3900),
            new UserEmployee("David Williams", "E004", 6100),
            new UserEmployee("Emma Wilson", "E005", 7200),
            new UserEmployee("Franklin Taylor", "E006", 3300),
            new UserEmployee("Grace Adams", "E007", 4500),
            new UserEmployee("Hannah Lee", "E008", 5600),
            new UserEmployee("Isaac Martin", "E009", 4100),
            new UserEmployee("Jack Thompson", "E010", 3000),
            new UserEmployee("Kelly White", "E011", 5200),
            new UserEmployee("Liam Harris", "E012", 6800),
            new UserEmployee("Mia Clark", "E013", 4900),
            new UserEmployee("Noah Lewis", "E014", 3700),
            new UserEmployee("Olivia Walker", "E015", 5900),
            new UserEmployee("Peter Hall", "E016", 3400),
            new UserEmployee("Quinn Young", "E017", 4800),
            new UserEmployee("Rachel King", "E018", 6300),
            new UserEmployee("Samuel Wright", "E019", 5500),
            new UserEmployee("Tina Scott", "E020", 7100)
        };

        Report report = new Report();
        report.ReportProcessor(usersEmployees, "Users that total sales less than 4000", (e) => e.TotalSales < 4000);
        report.ReportProcessor(usersEmployees, "Users that total sales grater than 5000", (e) => e.TotalSales > 5000);


        //------------------------
        // event example : 
        Stock stock = new Stock("Google");
        stock.Price = 100;
        stock.onPriceChanged += StockOnonPriceChanged;
        stock.ChangeStockByPrice(0.05m);
        stock.ChangeStockByPrice(-0.02m);
        stock.ChangeStockByPrice(0.00m);
        
        IEnumerable<int> numbers = new List<int> { 1, 2, 3, 4, 5,10,11,123,13,20 };
        
        //-----  builtIn delegts Example :  we can use predicate and func and action
        BuiltInGenericDelegetsExample.
            FindEmlementsAccordingToStatement(numbers, (number) => number > 5);
        BuiltInGenericDelegetsExample.
            FindEmlementsAccordingToStatement(numbers, (number) => number < 5);
        BuiltInGenericDelegetsExample.
            FindEmlementsAccordingToStatement(numbers, (number) => number % 2 == 0);
        
        // another example on action and func and predicate : 
        NumberProcessor numberProcessor = new NumberProcessor();
        numberProcessor.Operation = (x, y) => x * y; // Multiplication
        int result = numberProcessor.ExecuteOperation(4, 5);
        Console.WriteLine($"Result: {result}"); // Output: 20
        
        // 2. Using Action<string>
        numberProcessor.Logger = message => Console.WriteLine($"[INFO] {message}");
        numberProcessor.Logger("Processing complete!"); 
        
        // 3. Using Predicate<int>
        numberProcessor.Condition = num => num % 2 == 0; // Filter even numbers
        List<int> numbersForProcessor = new List<int> { 1, 2, 3, 4, 5, 6 };
        List<int> evenNumbers = numberProcessor.FilterNumbers(numbersForProcessor);
        
        Console.WriteLine("Even Numbers: " + string.Join(", ", evenNumbers)); // Output: 2, 4, 6
        
        /*
         Explanation:
        Func<int, int, int> (Operation)
        Used to perform an arithmetic operation (default is addition, but we change it to multiplication in Main).
        
        Action<string> (Logger)
        Used to log messages in different formats.
        
        Predicate<int> (Condition)
        Used to filter numbers based on conditions (e.g., filtering even numbers).
         */
        
        
        
        // methode extension example : 
        DateTime dt = DateTime.Now;
        Console.WriteLine($"DateTime Now : {dt}");
        dt.AddDays(4);
        Console.WriteLine($"Is WeekEnd: {dt.IsWeekend()}");
        Console.WriteLine($"Is Week day: {dt.IsWeekDay()}");

        // another example: 
        Pizza p = new Pizza();

        //p = PizzaExtensions.AddDough(PizzaExtensions.AddSauce(PizzaExtensions.AddCheeze(PizzaExtensions.AddToppings(p, "black olives", 3.5m), true)), "thin");
        p.AddDough("thin")
            .AddSauce()
            .AddCheeze(true)
            .AddToppings("black olives", 3.5m);
        Console.WriteLine(p);
    }

    private static void StockOnonPriceChanged(Stock stock, decimal oldprice)
    {
        if (stock.Price > oldprice)
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        else if (stock.Price < oldprice)
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        Console.WriteLine($"{stock.Name}, {stock.Price}");
    }

    //Exeprission body methode : 
    public static bool isEven(int number) => number % 2 == 0;
}