namespace RecipeApp.Dto;

public class UpdateRecipeDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int? CountryId { get; set; }
    public string? PhotoUrl { get; set; }
}