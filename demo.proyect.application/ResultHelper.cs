namespace demo.proyect.application;

public static class ResultHelper 
{ 
    public static Result<T> Success<T>(this T data) => Result<T>.Success(data);
    
    public static Result<bool> Success() => Result<bool>.Success();
    
    public static Result<T> Failure<T>(this T data, string message = "Resultado no sastisfactorio")
    => Result<T>.Failure(message, data);
}