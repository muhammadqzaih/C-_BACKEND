public class Program
{
    static void Main(string[] args)
    {
        var th = new Thread(()=>Display("This is a test!"));
        th.Start();
        
        // we can use Task class to avoid make a new thread :
        // Task class provide use  pooled thread!  
        // Task class is an abstracion aproch 
        // this enhance the performance by resue the pooled threads!! 
        // Task can return a value !! but thread can not !!
        Task.Run(() =>  Display("This is a test!")).Wait();
        // there is two types of task class (task class and generic task class ) 

        Task<DateTime> date = Task.Run(GetDateTimeNow);
        Console.WriteLine(date);// System.Threading.Tasks.Task`1[System.DateTime]
        // to access the value of the Task object should use .Result : 
         Console.WriteLine(date.Result);// this make a block!!!!!!! be careful!!!
        // another way: 
        Console.WriteLine(date.GetAwaiter().GetResult());
        
    }
    static DateTime GetDateTimeNow() => DateTime.Now;
    private static void Display(string thisIsATest)
    {
        Console.WriteLine(thisIsATest);
    }
}