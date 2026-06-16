using RecipeApp.Api.Models.Requests;
using RecipeApp.Api.Models.Responses;
using RecipeApp.Dto;

namespace RecipeApp.Api.Mappers
{
    public static class IngredientMapper
    {
        public static CreateIngredientDto toDto(CreateIngredientRequestModel request)
        {
            var dto = new CreateIngredientDto
            {
                Name = request.Name,
            };

            return dto;
        }
        public static IngredientResponseModel ToModel(IngredientDto ingredientDto)
        {
            return new IngredientResponseModel
            {
                Id = ingredientDto.Id,
                Name = ingredientDto.Name
            };
        }

        public static List<IngredientResponseModel> ToModel(List<IngredientDto> ingredientDto)
        {
            return ingredientDto.Select(c => ToModel(c)).ToList();
        }


    }
}
        