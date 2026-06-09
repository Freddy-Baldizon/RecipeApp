using Microsoft.EntityFrameworkCore;
using RecipeApp.Domain.Entities;
namespace RecipeApp.Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _dbContext;
        public async Task<Comment> AddAsync(Comment comment)
        {
            await _dbContext.Comment.AddAsync(comment);
            return comment;
        }

        public async Task DeleteAsync(Comment comment)
        {
            _dbContext.Comment.Remove(comment);
            await _dbContext.SaveChangesAsync(); 
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _dbContext.Comment.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int commentId)
        {
            return await _dbContext.Comment.FindAsync(commentId);
        }
    }
}