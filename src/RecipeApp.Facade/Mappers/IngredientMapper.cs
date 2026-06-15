using RecipeApp.Domain.Entities;
using RecipeApp.Dto;
namespace RecipeApp.Facade.Mappers
{
    public class IngredientMapper
    {
        public static List<IngredientDto> ToDto(List<IngredientDto> ingredients)
        {
            return ingredients.Select(p => ToDto(p)).ToList();
        }
        public static IngredientDto ToDto(IngredientDto ingredient)
        {
            return new IngredientDto
            {
               Id = ingredient.Id,
               Name = ingredient.Name,
               Amount = ingredient.Amount
            };
        }
    }
}