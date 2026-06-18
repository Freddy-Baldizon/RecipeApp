using System.Runtime.CompilerServices;
namespace RecipeApp.Dto;

public class FavoriteDto
{
    public int RecipeId { get; set; }
    public int UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public RecipeDto? Recipe { get; set; }
}