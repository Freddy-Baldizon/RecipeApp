using RecipeApp.Domain.Entities;
using RecipeApp.DomainService.Interfaces;
using RecipeApp.Exceptions;
using RecipeApp.Infrastructure.Repositories.Interfaces;
using RecipeApp.Dto;

namespace RecipeApp.DomainService.Classes;

public class StepService : IStepService
{
    private readonly IStepRepository _stepRepository;

    public StepService(IStepRepository stepRepository)
    {
        _stepRepository = stepRepository;
    }

    public Task<List<Step>> GetAllAsync()
        => _stepRepository.GetAllAsync();

    public async Task<Step> AddAsync(StepDto stepDto)
    {
        var newStep = new Step
        {
            RecipeId = stepDto.RecipeId,
            Description = stepDto.Description,
        };
        return await _stepRepository.AddAsync(newStep);
    }

    public async Task DeleteAsync(int id)
    {
        var steps = await _stepRepository.GetAllAsync();
        var step = steps.FirstOrDefault(s => s.Id == id);

        if (step == null)
            throw new ResourceNotFoundException($"Step with ID {id} not found.");

        await _stepRepository.DeleteAsync(step);
    }
}