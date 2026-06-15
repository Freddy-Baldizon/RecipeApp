using RecipeApp.Api.Models.Requests;
using RecipeApp.Api.Models.Responses;
using RecipeApp.Dto;

namespace RecipeApp.Api.Mappers
{
    public class RatingMapper
    {
        public static RatingDto ToDto(CreateRatingRequestModel ratingRequestModel)
        {
            return new RatingDto
            {
                UserId = ratingRequestModel.UserId,
                RecipeId = ratingRequestModel.RecipeId,
                Value = ratingRequestModel.Value
            };
        }
        public static RatingResponseModel ToModel(RatingDto ratingDto)
        {
            return new RatingResponseModel
            {
                Id = ratingDto.Id,
                UserId = ratingDto.UserId,
                RecipeId = ratingDto.RecipeId,
                Value = ratingDto.Value
            };
        }
    }
}