namespace RecipeApp.Dto;

public class RecipeDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int CountryId { get; set; }
    public int UserId { get; set; }
    public string? CountryFlag { get; set; }
    public string? CountryName { get; set; }
    public string? Username { get; set; }
    public string? PhotoUrl { get; set; }
    public int FavoritesCount { get; set; } 
    public List<IngredientDto?> Ingredients { get; set; } = [];
    public List<CommentDto?> Comments { get; set; } = [];
}