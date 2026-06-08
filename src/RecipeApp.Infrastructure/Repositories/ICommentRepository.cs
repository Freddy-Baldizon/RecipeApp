using ProyectoSW4.Domain.Entities;

namespace recipeApp.Infrastructure.Repositories
{
    public interface IProductRepository
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(Guid commentId);
        Task<Comment> AddAsync(Comment comment);
        Task DeleteAsync(Comment comment);
    }
}