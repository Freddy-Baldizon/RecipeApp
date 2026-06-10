namespace RecipeApp.Dto;

public class AuthorizationRequestDto
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}