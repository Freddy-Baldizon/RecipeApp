using System.ComponentModel.DataAnnotations;

namespace RecipeApp.Api.Models.Requests;

public class CreateCommentRequestModel
{
    [Required]
    public int UserId { get; set; }

    [Required]
    public int RecipeId { get; set; }
    
    [MaxLength(255)]
    [Required]
    public string? Username {get; set;}

    [Required]
    [MaxLength(200)]
    public required string Title { get; set; }

    [Required]
    [MaxLength(1000)]
    public required string Description { get; set; }
}