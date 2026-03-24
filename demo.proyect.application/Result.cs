namespace demo.proyect.application;

public class Result<T>
{
    public bool IsSuccess { get; set; }
    public T Data { get; set; }
    public string Message { get; set; }

    public static Result<T> Success() => new()
    {
        IsSuccess = true,
    };

    public static Result<T> Success(string message) => new()
    {
        IsSuccess = true,
        Message = message
    };

    public static Result<T> Success(T data) => new()
    {
        IsSuccess = true,
        Data = data
    };

    public static Result<T> Success(string message, T data) => new()
    {
        IsSuccess = true,
        Message = message,
        Data = data
    };

    public static Result<T> Failure(string messages) => new()
    {
        IsSuccess = false,
        Message = messages
    };

    public static Result<T> Failure(string messages, T data) => new()
    {
        IsSuccess = false,
        Message = messages,
        Data = data
    };
}
