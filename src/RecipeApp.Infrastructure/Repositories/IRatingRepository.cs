using System;
using RecipeApp.Domain.Entities;
namespace RecipeApp.Infrastructure.Repositories
{
    public interface IRatingRepository
    {
        Task<Rating> GetByIdAsync(Guid id);
        Task AddAsync(Rating rating);
        Task DeleteAsync(Guid id);
    }
}