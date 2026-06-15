using RecipeApp.Domain.Entities;
using RecipeApp.Dto;
namespace RecipeApp.Facade.Mappers
{
    public class RatingMapper
    {
        public static List<RatingDto> ToDto(List<RatingDto> ratings)
        {
            return ratings.Select(p => ToDto(p)).ToList();
        }
        public static RatingDto ToDto(RatingDto rating)
        {
            return new RatingDto
            {
                Id = rating.Id,
                UserId = rating.UserId,
                RecipeId = rating.RecipeId,
                Value = rating.Value
            };
        }
    }
}