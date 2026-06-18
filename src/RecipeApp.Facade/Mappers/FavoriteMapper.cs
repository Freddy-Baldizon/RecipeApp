using System.Data.Common;
using RecipeApp.Domain.Entities;
using RecipeApp.Dto;
namespace RecipeApp.Facade.Mappers
{
    public class FavoriteMapper
    {
        public static List<FavoriteDto> ToDto(List<Favorite> favorites)
        {
            return favorites.Select(p => ToDto(p)).ToList();
        }
        public static FavoriteDto ToDto(Favorite favorite)
        {
            return new FavoriteDto
            {
                UserId = favorite.UserId,
                CreatedAt = favorite.CreatedAt,
                RecipeId = favorite.RecipeId,
                Recipe = favorite.Recipe != null ? RecipeMapper.ToDto(favorite.Recipe) : null
            };
        }
    }
}