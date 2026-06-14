using Microsoft.EntityFrameworkCore;
using RecipeApp.Domain.Entities;
using RecipeApp.Infrastructure.Repositories.Interfaces;

namespace RecipeApp.Infrastructure.Repositories.Classes;

public class StepRepository : IStepRepository
{
    private readonly AppDbContext _dbContext;

    public StepRepository(AppDbContext context)
    {
        _dbContext = context;
    }

    public async Task<List<Step>> GetAllAsync()
    {
        return await _dbContext.Step.ToListAsync();
    }

    public async Task<Step> AddAsync(Step step)
    {
        await _dbContext.Step.AddAsync(step);
        return step;
    }

    public async Task DeleteAsync(Step step)
    {
        _dbContext.Step.Remove(step);
        await _dbContext.SaveChangesAsync();
        
    }
}