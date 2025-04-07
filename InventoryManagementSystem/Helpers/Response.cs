namespace InventoryManagementSystem.Helpers;

public class Response<T>
{
    public bool Success { get; }
    public string Message { get; }
    public T? Data { get; }

    public Response(T data, string message)
    {
        Success = true;
        Message = message;
        Data = data;
    }

    public Response(string message)
    {
        Success = false;
        Message = message;
        Data = default;
    }
}