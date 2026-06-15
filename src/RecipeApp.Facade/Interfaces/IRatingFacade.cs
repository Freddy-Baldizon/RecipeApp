using RecipeApp.Dto;

namespace RecipeApp.Facade.Interfaces
{
    public interface IRatingFacade
    {
        Task<RatingDto> AddAsync(RatingDto ratingDto);
        Task<RatingDto?> GetByRecipeIdAsync(int id);
        Task<List<RatingDto>> GetAllByRecipeIdAsync(int recipeId);
        Task DeleteAsync(int id);
        Task<List<RatingDto>> GetRatingByUserId(int userId);
        Task<List<RatingDto>> GetRatingByRecipeId(int recipeId);

        Task UpdateAsync(int id, RatingDto ratingDto);
    }
}