using RecipeApp.Domain.Entities;
using RecipeApp.Dto;

namespace RecipeApp.DomainService
{
    public interface IRatingService
    {
        Task<Rating> GetByIdAsync(int id);
        Task<Rating> AddAsync(RatingDto rating);
        Task DeleteAsync(RatingDto rating);
        Task<List<Rating>> GetRatingByUserId(int userId);
        Task<List<Rating>> GetRatingByRecipeId(int recipeId);
    }
}