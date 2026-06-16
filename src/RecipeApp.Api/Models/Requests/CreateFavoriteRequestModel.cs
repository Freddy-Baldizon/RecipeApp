using System.ComponentModel.DataAnnotations;

namespace RecipeApp.Api.Models.Requests;

public class CreateFavoriteRequestModel
{
    [Required]
    public int RecipeId { get; set; }

    [Required]
    public int UserId { get; set; }
}
