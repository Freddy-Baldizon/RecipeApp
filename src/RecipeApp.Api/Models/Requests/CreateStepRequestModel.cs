using System.ComponentModel.DataAnnotations;

namespace RecipeApp.Api.Models.Requests;

public class CreateStepRequestModel
{
    [Required]
    public int RecipeId { get; set; }

    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }

    [MaxLength(1000)]
    public string? Description { get; set; }

    [Required]
    public int Order { get; set; }
}