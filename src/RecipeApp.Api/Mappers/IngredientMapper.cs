using RecipeApp.Api.Models.Requests;
using RecipeApp.Api.Models.Responses;
using RecipeApp.Dto;

namespace RecipeApp.Api.Mappers
{
    public static class IngredientMapper
    {
        public static IngredientResponseModel ToModel(IngredientDto ingredientDto)
        {
            return new IngredientResponseModel
            {
                Id = ingredientDto.Id,
                Name = ingredientDto.Name,
                Amount = ingredientDto.Amount
            };
        }

        public static List<IngredientResponseModel> ToModel(List<IngredientDto> ingredientDto)
        {
            return ingredientDto.Select(c => ToModel(c)).ToList();

        }


    }
}
        