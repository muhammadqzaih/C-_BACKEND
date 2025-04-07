namespace ConsoleApp1.Events.Example2;

public class TemperatureSensor
{
   private int temperature;
   public int Temperature {get => temperature; set => temperature = value; }
   public event TemperatureThresholdHandler temperatureOnChanged;
   public TemperatureSensor(int temperature)
   {
      this.temperature = temperature;
   }
   
   
   

}