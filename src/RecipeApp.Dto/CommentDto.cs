namespace RecipeApp.Dto;

public class CommentDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string? Username { get; set; }
    public int RecipeId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
}