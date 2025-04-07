namespace ConsoleApp1;

public class Employee
{
    public static double TAX = 0.03;

    public string fName;
    public string lName;
    public string lAddress;
    public string Id;

    public void printInfo()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"FName: {fName}");
        Console.WriteLine($"LName: {lName}");
        Console.WriteLine($"Address: {lAddress}");
    }
}