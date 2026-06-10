namespace RecipeApp.Dto;

public class AuthorizationResponseDto
{
    public string? Token { get; set; }
    public int UserId { get; set; }
    public string? Email { get; set; }
    public string? Username { get; set; }
    public string? Avatar { get; set; }
}