namespace RecipeApp.Exceptions;

public class ResourceNotFoundException : MessageException
{
    public ResourceNotFoundException() 
        : base("Resource not found.", 404) { }

    public ResourceNotFoundException(string message) 
        : base(message, 404) { }
}
