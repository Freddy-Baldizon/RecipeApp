using RecipeApp.Domain.Entities;

namespace RecipeApp.Infrastructure.Repositories
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllByRecipeIdAsync(int recipeId);
        Task<Comment?> GetByIdAsync(int commentId);
        Task<Comment> AddAsync(Comment comment);
        Task DeleteAsync(Comment comment);
    }
}