public class ClassSda
{
    static void Main(string[] args)
    {
        TaskUsedDelayResult(5000);
        //ThreadUsedSleepResult(5000);
    }

    private static void TaskUsedDelayResult(int i)
    {
        // task make logical delay !! but we should make it as a task !!  
        Task.Delay(i)
            .GetAwaiter()
            .OnCompleted(() => { Console.WriteLine($"Result Completed after {i} seconds"); });
    }

    private static void ThreadUsedSleepResult(int i)
    {
        Thread.Sleep(i);
        Console.WriteLine($"Result Completed after {i} seconds");
    }
}