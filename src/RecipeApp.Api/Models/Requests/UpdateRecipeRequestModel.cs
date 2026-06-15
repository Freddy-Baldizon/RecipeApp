using System.ComponentModel.DataAnnotations;

namespace RecipeApp.Api.Models.Requests;

public class UpdateRecipeRequestModel
{
    [MaxLength(100)]
    public string? Name { get; set; }

    [MaxLength(1000)]
    public string? Description { get; set; }

    public int? CountryId { get; set; }

    [Url]
    [MaxLength(2048)]
    public string? PhotoUrl { get; set; }
}