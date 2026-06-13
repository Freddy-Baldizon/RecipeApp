namespace RecipeApp.Dto;

public class AuthorizationResponseDto
{
    public  required string Token { get; set; }
    public required DateTime ExpiresIn { get; set; }
    
}