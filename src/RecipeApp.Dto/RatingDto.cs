namespace RecipeApp.Dto;

public class RatingDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int RecipeId { get; set; }
    public int Value { get; set; }
}