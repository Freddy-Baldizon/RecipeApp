using RecipeApp.Domain.Entities;
using RecipeApp.Dto;

namespace RecipeApp.DomainService.Interfaces
{
    public interface ICommentService
    {
        Task<Comment> AddAsync(CommentDto commentDto);
        Task<Comment> GetByIdAsync(int id);
        Task<List<Comment>> GetAllByRecipeIdAsync(int recipeId);
        Task<Comment> UpdateAsync(CommentDto commentDto);
        Task DeleteAsync(int id);
    }
}