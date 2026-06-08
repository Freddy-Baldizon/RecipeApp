namespace RecipeApp.Exceptions;

public class DuplicateResourceException : MessageException
{
    public DuplicateResourceException() 
        : base("Resource already exists.", 409) { }

    public DuplicateResourceException(string message) 
        : base(message, 409) { }
}
