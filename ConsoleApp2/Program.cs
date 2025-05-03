using System.Reflection;

/*

 What Are Attributes in C#?
Attributes in C# are a way to add metadata to your code. 
They provide additional information about code elements (classes, methods, properties, parameters, etc.), 
which can be accessed at runtime using reflection.

Attributes are enclosed in square brackets [] and are placed above the element they apply to.

Why Do We Need Attributes?
Metadata & Code Annotation: They provide additional information about program elements.
Runtime Reflection: You can retrieve and process attribute information at runtime.
Framework Integration: Many .NET frameworks (ASP.NET, Entity Framework, etc.) use attributes for configuration.
Code Generation & Interoperability: Used for serialization, API documentation, etc.

 */
public class Program
{
    static void Main(string[] args)
    {
        List<Player> players = new List<Player>
        {
            new Player
            {
                Name = "Lionel Messi",
                BallControl = 9,
                Dribbling = 18,
                Passing = 4,
                Speed = 85,
                Power = 990
            },
            new Player
            {
                Name = "Christiano Ronaldo",
                BallControl = 9,
                Dribbling = 21,
                Passing = 4,
                Speed = 110,
                Power = 980
            },
            new Player
            {
                Name = "Naymar Jr",
                BallControl = 11,
                Dribbling = 16,
                Passing = 4,
                Speed = 85,
                Power = 1000
            }
        };
        var errors = new List<Error>();
        foreach (var player in players)
        {
            var properties = player.GetType().GetProperties();
            foreach (var prop in properties)
            {
                var skillAttribute = prop.GetCustomAttribute<SkillAttribute>();
                if (skillAttribute is not null)
                {
                    var value = prop.GetValue(player);
                    if (!skillAttribute.IsValid(value))
                    {
                        errors.Add(new Error(prop.Name,
                            $"Invalid value Accepted Range is {skillAttribute.Minimum}-{skillAttribute.Maximum}"));
                    }
                }
            }
        }

        if (errors.Count > 0)
        {
            foreach (var e in errors)
            {
                Console.WriteLine(e);
            }
        }
        else
        {
            Console.WriteLine("players info are valid");
        }

        Console.ReadKey();
    }
}

public class Player
{
    public string Name { get; set; }

    [Skill(nameof(BallControl), 1, 10)] public int BallControl { get; set; }
    [Skill(nameof(Dribbling), 1, 20)] public int Dribbling { get; set; }
    [Skill(nameof(Power), 1, 1000)] public int Power { get; set; }

    [Skill(nameof(Speed), 1, 100)] public int Speed { get; set; }

    [Skill(nameof(Passing), 1, 100)] public int Passing { get; set; }
}


public class SkillAttribute : Attribute
{
    public string Name { get; set; }
    public int Maximum { get; set; }
    public int Minimum { get; set; }

    public SkillAttribute(string name, int minimum, int maximum)
    {
        Name = name;
        minimum = Minimum;
        maximum = Maximum;
    }

    public bool IsValid(Object obj)
    {
        var value = (int)obj;
        return value >= this.Minimum && value <= this.Maximum;
    }
}
public class Error
{
    private string field;
    private string details;

    public Error(string field, string details)
    {
        this.field = field;
        this.details = details;
    }

    public override string ToString()
    {
        return $"{{\"{field}\": \"{details}\"}}";
    }
}