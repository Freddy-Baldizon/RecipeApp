namespace RecipeApp.Api.Models.Responses;

public class StepResponseModel
{
    public int Id { get; set; }
    public int RecipeId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int Order { get; set; }
}