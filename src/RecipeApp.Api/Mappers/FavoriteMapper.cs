using RecipeApp.Api.Models.Requests;
using RecipeApp.Api.Models.Responses;
using RecipeApp.Domain.Entities;
using RecipeApp.Dto;

namespace RecipeApp.Api.Mappers
{
    public static class FavoriteMapper
    {
        public static FavoriteDto ToDto(CreateFavoriteRequestModel request)
        {
            var dto = new FavoriteDto
            {
                UserId = request.UserId,
                RecipeId = request.RecipeId
            };

            return dto;
        }
        public static FavoriteResponseModel ToModel(FavoriteDto favoriteDto)
        {
            return new FavoriteResponseModel
            {
                recipeId = favoriteDto.RecipeId,
                createdAt = favoriteDto.CreatedAt,
                Recipe = favoriteDto.Recipe != null ? RecipeMapper.ToModel(favoriteDto.Recipe) : null
            };
        }

        public static List<FavoriteResponseModel> ToModel(List<FavoriteDto> FavoriteDto)
        {
            return FavoriteDto.Select(c => ToModel(c)).ToList();
        }


    }
}
        