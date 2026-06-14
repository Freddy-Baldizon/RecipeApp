using RecipeApp.Domain.Entities;
using RecipeApp.Dto;

namespace RecipeApp.DomainService.Interfaces;

public interface IStepService
{
    Task<List<Step>> GetAllAsync();
    Task<Step> UpdateAsync(Step step);
    Task<Step> AddAsync(Step step);
    Task DeleteAsync(int id);
}