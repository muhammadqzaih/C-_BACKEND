using LINQ_6.EmployeeDTO;
using LINQ_6.Repository;

public class MainClass
{
    static void Main(string[] args)
    {
        RunJoin();
    }

    private static void RunJoin()
    {
        var employees = Repository.LoadEmployees();
        var departments = Repository.LoadDepartment();

        var result =
            employees.Join(departments,
                e => e.DepartmentId,
                d => d.Id,
                (emp, dep) => new EmployeeDto
                {
                    FullName = emp.FullName,
                    Department = dep.Name
                });
        foreach (var joinedEmployee in result)
        {
            Console.WriteLine($"{joinedEmployee.FullName}, {joinedEmployee.Department}");
        }
    }
}