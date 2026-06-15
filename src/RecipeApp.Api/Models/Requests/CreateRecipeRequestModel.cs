using System.ComponentModel.DataAnnotations;

namespace RecipeApp.Api.Models.Requests;

public class CreateRecipeRequestModel
{
    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }

    [MaxLength(1000)]
    public string? Description { get; set; }

    [Required]
    public int CountryId { get; set; }

    [Required]
    public int UserId { get; set; }

    [Url]
    [MaxLength(2048)]
    public string? PhotoUrl { get; set; }
}