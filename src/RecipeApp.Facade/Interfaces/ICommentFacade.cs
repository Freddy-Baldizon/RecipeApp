using RecipeApp.Domain.Entities;
using RecipeApp.Dto;

namespace RecipeApp.Facade.Interfaces
{
    public interface ICommentFacade
    {
        Task<CommentDto> AddAsync(CommentDto commentDto);
        Task<CommentDto> GetByIdAsync(int id);
        Task<List<CommentDto>> GetAllByRecipeIdAsync(int recipeId);
        Task DeleteAsync(int id);

        Task UpdateAsync(int id, CommentDto commentDto);
    }
}