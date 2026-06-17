using RecipeApp.Domain.Entities;
using RecipeApp.Dto;
namespace RecipeApp.Facade.Mappers
{
    public class RecipeMapper
    {
        public static List<RecipeDto> ToDto(List<Recipe> recipes)
        {
            return recipes.Select(p => ToDto(p)).ToList();
        }
        public static RecipeDto ToDto(Recipe recipe)
        {
            return new RecipeDto
            {
                Id = recipe.Id,
                Name = recipe.Name,
                UserId = recipe.UserId,
                CountryId = recipe.CountryId,
                CountryFlag = recipe.Country?.FlagUrl,
                CountryName = recipe.Country?.Name,
                Username = recipe.User?.Username,
                Description = recipe.Description,
                PhotoUrl = recipe.PhotoUrl,
                Ingredients = recipe.RecipeIngredients.Select(ri => new RecipeIngredientDto
                {
                    IngredientId = ri.IngredientId,
                    IngredientName = ri.Ingredient?.Name,
                    Amount = ri.Amount
                }).ToList()
            };
        }
    }
}
