using System;
using RecipeApp.Domain.Entities;
namespace RecipeApp.Infrastructure.Repositories.Interfaces
{
    public interface IRatingRepository
    {
        Task<Rating> GetByIdAsync(int id);
        Task<Rating> AddAsync(Rating rating);
        Task<List<Rating>> GetRatingByUserId(int userId);
        Task<List<Rating>> GetRatingByRecipeId(int recipeId);
        Task DeleteAsync(Rating rating);
    }
}