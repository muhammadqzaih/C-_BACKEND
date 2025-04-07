namespace ConsoleApp1.MethodeExtensionExample;

public static  class DateTimeExtension
{
    public static bool IsWeekend(this DateTime value)
    {
        return value.DayOfWeek == DayOfWeek.Saturday || value.DayOfWeek == DayOfWeek.Sunday;
    }

    public static bool IsWeekDay(this DateTime value)
    {
        return !IsWeekend(value);
    }
}