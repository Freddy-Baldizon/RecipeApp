using RecipeApp.Domain.Entities;
using RecipeApp.Dto;

namespace RecipeApp.DomainService.Interfaces;

public interface IStepService
{
    Task<List<Step>> GetAllAsync();
<<<<<<< HEAD
    Task<Step> AddAsync(StepDto stepDto);
=======
    Task<Step> UpdateAsync(Step step);
    Task<Step> AddAsync(Step step);
>>>>>>> Freddy
    Task DeleteAsync(int id);
}