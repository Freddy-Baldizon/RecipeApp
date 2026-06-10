namespace RecipeApp.Dto;

public class StepDto
{
    public int Id { get; set; }
    public int RecipeId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int Order { get; set; }
}