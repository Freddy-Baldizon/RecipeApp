using RecipeApp.Domain.Entities;
using RecipeApp.Dto;
namespace RecipeApp.Facade.Mappers
{
    public class StepMapper
    {
        public static List<StepDto> ToDto(List<StepDto> steps)
        {
            return steps.Select(p => ToDto(p)).ToList();
        }
        public static StepDto ToDto(StepDto step)
        {
            return new StepDto
            {
                Id = step.Id,
                Name = step.Name,
                RecipeId = step.RecipeId,
                Description = step.Description,
                Order = step.Order
            };
        }
    }
}