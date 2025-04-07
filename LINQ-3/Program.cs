using LINQ_3;
using LINQ_3.Shared;

public class Client
{
    //Projection Operation
    static void Main(string[] args)
    {
        // Select
        var employees = EmployeeRepository.LoadEmployees();
        var employeeDataTransfer =
            employees.Select(e => new EmployeeDTO
            {
                Name = e.FirstName + " " + e.LastName,
                TotalSkills = e.Skills.Count,
            });

        foreach (var employee in employeeDataTransfer)
        {
            Console.WriteLine(employee);
        }
        // -------------- Select Many!! 
        /*
         SelectMany is useful when you have a collection of collections (nested lists)
         and you want to flatten them into a single sequence.

        For example, in an Employee class, each employee might have multiple Skills.
        If we want to retrieve all the skills across all employees as a single list,
        SelectMany is the best choice.
         */

        var employeesSkills = employees
            .SelectMany(e => e.Skills)
            .Distinct();

        foreach (var employee in employeesSkills)
        {
            Console.WriteLine(employee);
        }
    }
}