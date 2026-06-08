namespace RecipeApp.Exceptions;

public class ForbiddenResponseException : MessageException
{
    public ForbiddenResponseException() 
        : base("You do not have permission to perform this action.", 403) { }

    public ForbiddenResponseException(string message) 
        : base(message, 403) { }
}
