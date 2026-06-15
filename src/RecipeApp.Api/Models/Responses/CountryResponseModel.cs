namespace RecipeApp.Api.Models.Responses;

public class CountryResponseModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? FlagUrl { get; set; }
    public string? IsoAlpha3 { get; set; }
}