using RecipeApp.Api.Models.Requests;
using RecipeApp.Api.Models.Responses;
using RecipeApp.Dto;

namespace RecipeApp.Api.Mappers
{
    public class StepMapper
    {
        public static StepDto ToDto(CreateStepRequestModel stepRequest)
        {
            return new StepDto
            {
                RecipeId = stepRequest.RecipeId,
                Name = stepRequest.Name,
                Description = stepRequest.Description,
                Order = stepRequest.Order
            };
        }

        public static List<StepResponseModel> ToModel(List<StepDto> stepDtos)
        {
            return stepDtos.Select(s => ToModel(s)).ToList();
        }

        public static StepResponseModel ToModel(StepDto stepDto)
        {
            return new StepResponseModel
            {
                Id = stepDto.Id,
                RecipeId = stepDto.RecipeId,
                Name = stepDto.Name,
                Description = stepDto.Description,
                Order = stepDto.Order
            };
        }
    }
}