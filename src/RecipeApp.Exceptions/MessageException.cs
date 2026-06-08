namespace RecipeApp.Exceptions;

public class MessageException : Exception
{
    public int StatusCode { get; }

    public MessageException(string message, int statusCode) : base(message)
    {
        StatusCode = statusCode;
    }
}
