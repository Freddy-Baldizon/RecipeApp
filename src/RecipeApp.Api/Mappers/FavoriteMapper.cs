using RecipeApp.Api.Models.Requests;
using RecipeApp.Api.Models.Responses;
using RecipeApp.Domain.Entities;
using RecipeApp.Dto;

namespace RecipeApp.Api.Mappers
{
    public static class FavoriteMapper
    {
        public static CreateFavoriteDto toDto(CreateFavoriteRequestModel request)
        {
            var dto = new CreateFavoriteDto
            {
                userId = request.UserId,
                recipId = request.RecipeId
            };

            return dto;
        }
        public static FavoriteResponseModel ToModel(FavoriteDto FavoriteDto)
        {
            return new FavoriteResponseModel
            {
                recipeId = FavoriteDto.RecipeId,
                createdAt = FavoriteDto.CreatedAt
            };
        }

        public static List<FavoriteResponseModel> ToModel(List<FavoriteDto> FavoriteDto)
        {
            return FavoriteDto.Select(c => ToModel(c)).ToList();
        }


    }
}
        