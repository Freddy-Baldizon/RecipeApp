namespace RecipeApp.Exceptions;

public class BadRequestResponseException : MessageException
{
    public BadRequestResponseException() 
        : base("Bad request.", 400) { }

    public BadRequestResponseException(string message) 
        : base(message, 400) { }
}
