using RecipeApp.Domain.Entities;

namespace RecipeApp.DomainService.Interfaces;
public interface IRatingService 
{
    Task<Rating> GetByIdAsync(int id);
    Task<Rating> AddAsync(Rating rating);
    Task<List<Rating>> GetRatingByUserId(int userId);
    Task<List<Rating>> GetRatingByRecipeId(int recipeId);
    Task DeleteAsync(int id);
}