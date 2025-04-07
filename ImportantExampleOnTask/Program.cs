public class Dev
{
    static void Main(string[] args)
    {
        Task<int> task = Task.Run(() => MakeLogic(1000));
     //   Console.WriteLine(task.Result);// bad !! its blocks the thread !! 
        
        
        // we can use anther way : 
        var awaiter = task.GetAwaiter();
        awaiter.OnCompleted(() =>
        {
            Console.WriteLine(awaiter.GetResult());// its block the thread but after task is complete !!!!!! 
        });
        // Now for simplification we can use ContinueWith methode in Task class !!! : 
        task.ContinueWith((x)=> Console.WriteLine(task.Result));
        
        // this printed before the above task !! 
        Console.WriteLine("another logic!!");
    }

    private static int MakeLogic(int value)
    {
        var result = 0;
        for (int i = 0; i < value; i++)
        {
            if (i == 991)
                result = i;
        }
        return result;
    }
}