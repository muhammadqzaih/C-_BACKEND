public class SyncAsyncOperations
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("asd asdasd");
       Task<int> resultTask =  GetContentAsync(
            "https://www.youtube.com/watch?v=kDUDX3VJFEc&list=PL4n1Qos4Tb6SWPbJNpiznp-Ok4A8J_23l&index=40");
       await Task.Run(()=> Console.WriteLine("my name"));
       Console.WriteLine(await resultTask);
    }

    static async Task<int> GetContentAsync(string url)
    {
        var client = new HttpClient();
        
        var result = await client.GetStringAsync(url);
        await Task.Delay(10000);
        return result.Length;
    }
}