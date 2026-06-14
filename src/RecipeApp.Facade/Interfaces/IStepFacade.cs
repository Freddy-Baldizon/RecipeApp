using RecipeApp.Dto;

namespace RecipeApp.Facade.Interfaces
{
    public interface IStepFacade
    {
        Task<List<StepDto>> GetAllAsync();
        Task<StepDto> AddAsync(StepDto stepDto);
        Task DeleteAsync(int id);
    }
}