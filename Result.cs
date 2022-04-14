namespace FP_Playground;

public class Result<T>
{
    public bool WasSuccessful { get; set; }
    public string Message { get; private set; }
    
    public T Model { get; private set; }

    public static Result<T> Error(string message) => new() {WasSuccessful = false, Message = message};
    public static Result<T> Success(T model) => new() {WasSuccessful = true, Model = model};
}