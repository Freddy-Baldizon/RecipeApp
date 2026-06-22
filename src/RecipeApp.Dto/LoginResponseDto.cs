namespace RecipeApp.Dto;

public class LoginResponseDto
{
    public required int id { get; set; }
    public required string email { get; set; }
    public required string username { get; set; }
    public required DateTime last_session { get; set; }
    public required string avatar { get; set; }
}