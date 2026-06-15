using System.ComponentModel.DataAnnotations;

namespace RecipeApp.Api.Models.Requests;

public class UpdateUserRequestModel
{
    [MaxLength(50)]
    public string? Username { get; set; }

    [Url]
    [MaxLength(2048)]
    public string? Avatar { get; set; }

    [MaxLength(255)]
    public string? Password { get; set; }
}