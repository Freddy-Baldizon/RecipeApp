using RecipeApp.Domain.Entities;
using RecipeApp.Dto;

namespace RecipeApp.DomainService;

public interface IStepService
{
    Task<List<Step>> GetAllAsync();
    Task<Step> AddAsync(Step step);
    Task DeleteAsync(int id);
}