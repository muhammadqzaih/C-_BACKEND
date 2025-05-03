namespace LINQ_3;

public class EmployeeDTO
{
    public string Name { get; set; }
    public int TotalSkills { get; set; }

    public override string ToString()
    {
        return $"{Name} ({TotalSkills})";
    }
}