using System;
using RecipeApp.Domain.Entities;
namespace RecipeApp.Infrastructure.Repositories
{
    public interface IRatingRepository
    {
        Task<Rating> GetByIdAsync(int id);
        Task<Rating> AddAsync(Rating rating);
        Task DeleteAsync(Rating rating);
    }
}