using System.ComponentModel.DataAnnotations;

namespace RecipeApp.Api.Models.Requests;

public class CreateRatingRequestModel
{
    [Required]
    public int UserId { get; set; }

    [Required]
    public int RecipeId { get; set; }

    [Required]
    [Range(1, 5)]
    public int Value { get; set; }
}