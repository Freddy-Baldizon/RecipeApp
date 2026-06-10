namespace RecipeApp.Dto;

public class RecipeDetailDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int CountryId { get; set; }
    public string? CountryName { get; set; }
    public string? CountryFlag { get; set; }
    public int UserId { get; set; }
    public string? Username { get; set; }
    public string? PhotoUrl { get; set; }
    public double AverageRating { get; set; }
    public List<StepDto> Steps { get; set; } = [];
    public List<IngredientDto> Ingredients { get; set; } = [];
    public List<CommentDto> Comments { get; set; } = [];
}