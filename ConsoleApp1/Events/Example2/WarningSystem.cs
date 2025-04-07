namespace ConsoleApp1.Events.Example2;

public class WarningSystem
{
    public void OnThresholdExceeded(object sender, int temperature)
    {
        // TODO: Display a warning message with the temperature
        Console.WriteLine("Temperature Changed: " + temperature);
    }
}