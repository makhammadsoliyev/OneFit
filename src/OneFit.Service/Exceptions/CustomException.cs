namespace OneFit.Service.Exceptions;

public class CustomException(int code, string message) : Exception(message)
{
    public int StatusCode { get; set; } = code;
}
