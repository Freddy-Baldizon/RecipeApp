using Microsoft.EntityFrameworkCore;
using RecipeApp.Domain.Entities;

namespace RecipeApp.Infrastructure.Repositories;

public class StepRepository : IStepRepository
{
    private readonly AppDbContext _context;

    public StepRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Step>> GetAllAsync()
    {
        return await _context.Step.ToListAsync();
    }

    public async Task<Step> AddAsync(Step step)
    {
        await _context.Step.AddAsync(step);
        return step;
    }

    public async Task DeleteAsync(Step step)
    {
        _context.Step.Remove(step);
        await _context.SaveChangesAsync();
    }
}