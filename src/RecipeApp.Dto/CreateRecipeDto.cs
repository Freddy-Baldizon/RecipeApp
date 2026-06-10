namespace RecipeApp.Dto;

public class CreateRecipeDto
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public int CountryId { get; set; }
    public int UserId { get; set; }
    public string? PhotoUrl { get; set; }
}