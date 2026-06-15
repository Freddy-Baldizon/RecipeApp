using RecipeApp.Domain.Entities;
using RecipeApp.Dto;

namespace RecipeApp.Facade.Interfaces
{
    public interface ICommentFacade
    {
        Task<CommentDto> AddAsync(CommentDto commentDto);
        Task<CommentDto> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task<CommentDto> UpdateAsync(CommentDto commentDto);
        Task<List<CommentDto>> GetAllByRecipeIdAsync(int recipeId);
    }
}