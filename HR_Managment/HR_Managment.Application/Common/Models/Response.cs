namespace HR_Managment.Application.Common.Models;

public class Response<T>
{
    public bool Succeeded { get; set; }
    public string Message { get; set; }
    public int StatusCode { get; set; }
    public T Data { get; set; }

    public static Response<T> Success(T data, string message = "")
        => new Response<T> { Succeeded = true, Data = data, Message = message, StatusCode = 200 };

    public static Response<T> Failed(string message, int statusCode = 400)
        => new Response<T> { Succeeded = false, Message = message, StatusCode = statusCode };
}
