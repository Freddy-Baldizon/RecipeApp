namespace RecipeApp.Api.Models.Responses;

public class RecipeResponseModel
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
    public List<StepResponseModel> Steps { get; set; } = new();
    public List<IngredientResponseModel> Ingredients { get; set; } = new();
    public List<CommentResponseModel> Comments { get; set; } = new();
}