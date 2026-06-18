namespace RecipeApp.Api.Models.Responses;

public class FavoriteResponseModel
{
    public int recipeId { get; set; }
    public DateTime createdAt { get; set; }
    public RecipeResponseModel? Recipe { get; set; }
}