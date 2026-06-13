using RecipeApp.Domain.Entities;
using RecipeApp.Dto;

namespace RecipeApp.DomainService
{
    public interface ICommentService
    {
        Task<Comment> AddAsync(CommentDto commentDto);
        Task<Comment> GetByIdAsync(int id);
        Task<List<Comment>> GetAllByRecipeIdAsync(int recipeId);
        Task DeleteAsync(int id);
    }
}