using System.ComponentModel.DataAnnotations;

namespace RecipeApp.Api.Models.Requests;

public class CreateUserRequestModel
{
    [Required]
    [EmailAddress]
    [MaxLength(100)]
    public required string Email { get; set; }

    [Required]
    [MaxLength(50)]
    public required string Username { get; set; }

    [Required]
    [MaxLength(255)]
    public required string Password { get; set; }

    [Url]
    [MaxLength(2048)]
    public string? Avatar { get; set; }
}