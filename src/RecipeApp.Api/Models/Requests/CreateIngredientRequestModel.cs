using System.ComponentModel.DataAnnotations;

namespace RecipeApp.Api.Models.Requests;

public class CreateIngredientRequestModel
{
    [Required]
    [MaxLength(255)]
    public required string Name { get; set; }
}