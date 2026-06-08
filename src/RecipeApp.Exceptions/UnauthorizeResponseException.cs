namespace RecipeApp.Exceptions;

public class UnauthorizedResponseException : MessageException
{
    public UnauthorizedResponseException() 
        : base("Unauthorized. Please log in.", 401) { }

    public UnauthorizedResponseException(string message) 
        : base(message, 401) { }
}
