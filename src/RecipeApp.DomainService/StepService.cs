using System.Linq;
using RecipeApp.Domain.Entities;
using RecipeApp.Exceptions;
using RecipeApp.Infrastructure.Repositories;

namespace RecipeApp.DomainService;

public class StepService : IStepService
{
    private readonly IStepRepository _stepRepository;

    public StepService(IStepRepository stepRepository)
    {
        _stepRepository = stepRepository;
    }

    public Task<List<Step>> GetAllAsync()
        => _stepRepository.GetAllAsync();

    public async Task<Step> AddAsync(Step step)
    {
        return await _stepRepository.AddAsync(step);
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