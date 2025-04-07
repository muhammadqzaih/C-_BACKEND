using LINQ.Implementations;

public class FirstExampleInLinq
{
    static void Main(string[] args)
    {
        //   RunExtensionProcedural();
        RunExtensionProceduralVersion2();
    }

    private static void RunExtensionProcedural()
    {
        var q1 = ExtnensionProcedural.GetEmployeesWithFirstNameStartsWith("ma");
        ExtnensionProcedural.Print(q1, "Employees with first name starts with 'ma'");

        var q2 = ExtnensionProcedural.GetEmployeesWithLastNameStartsWith("ju");
        ExtnensionProcedural.Print(q2, "Employees with last name starts with 'ju'");

        var q3 = ExtnensionProcedural.GetEmployeesWithDepartmentEqualsTo("hr");
        ExtnensionProcedural.Print(q3, "Employees in 'HR' department");

        var q4 = ExtnensionProcedural.GetEmployeesByGender("female");
        ExtnensionProcedural.Print(q4, "Female employees");

        var q5 = ExtnensionProcedural.GetEmployeesHiredInYear(2018);
        ExtnensionProcedural.Print(q5, "Employees hired in '2018'");

        var q6 = ExtnensionProcedural.GetEmployeesWithPensionPlanValueEqualsTo(true);
        ExtnensionProcedural.Print(q6, "Employees with Pension Plan");

        var q7 = ExtnensionProcedural.GetEmployeesWithHealthInsuranceValueEqualsTo(false);
        ExtnensionProcedural.Print(q7, "Employees without Health insurance");

        var q8 = ExtnensionProcedural.GetEmployeesWithSalaryEqualsTo(103200);
        ExtnensionProcedural.Print(q8, "Employees with Salary = $103200");

        var q9 = ExtnensionProcedural.GetEmployeesWithSalaryGreaterThan(107000);
        ExtnensionProcedural.Print(q9, "Employees with Salary > $107000");

        var q10 = ExtnensionProcedural.GetEmployeesWithSalaryLessThan(107000);
        ExtnensionProcedural.Print(q10, "Employees with Salary < $107000");
    }

    private static void RunExtensionProceduralVersion2()
    {
        var employees = EmployeeRepository.LoadEmployees();

        employees.Filter(e => e.FirstName.ToLowerInvariant().StartsWith("ma"))
            .Print("Employees with first name starts with 'ma'");

        var q2 = employees.Filter(e => e.LastName.ToLowerInvariant() == "ju");
        q2.Print("Employees with last name starts with 'ju'");

        var q3 = employees.Filter(e => e.Department.ToLowerInvariant() == "hr");
        q3.Print("Employees in 'HR' department");

        var q4 = employees.Filter(e => e.Gender.ToLowerInvariant() == "female");
        q4.Print("Female employees");

        var q5 = employees.Filter(e => e.HireDate.Year == 2018);
        q5.Print("Employees hired in '2018'");

        var q6 = employees.Filter(e => e.HasPensionPlan);
        q6.Print("Employees with Pension Plan");

        var q7 = employees.Filter(e => !e.HasHealthInsurance);
        q7.Print("Employees without Health insurance");

        var q8 = employees.Filter(e => e.Salary == 107000);
        q8.Print("Employees with Salary = $107000");

        var q9 = employees.Filter(e => e.Salary > 107000);
        q9.Print("Employees with Salary > $107000");

        var q10 = employees.Filter(e => e.Salary < 107000);
        q10.Print("Employees with Salary < $107000");

        var q11 = employees.Filter(e => e.Salary < 107000 && e.Gender == "female");
        q11.Print("Employees with Salary < $107000 and female");
    }
}