using System.ComponentModel.DataAnnotations;

namespace RecipeApp.Api.Models.Requests;

public class LoginRequestModel
{
    [Required]
    [EmailAddress]
    [MaxLength(100)]
    public required string Email { get; set; }

    [Required]
    [MaxLength(255)]
    public required string Password { get; set; }
}