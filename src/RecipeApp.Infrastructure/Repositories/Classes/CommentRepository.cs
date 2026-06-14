using Microsoft.EntityFrameworkCore;
using RecipeApp.Domain.Entities;
using RecipeApp.Infrastructure.Repositories.Interfaces;
namespace RecipeApp.Infrastructure.Repositories.Classes
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _dbContext;

        public CommentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
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
        public async Task<List<Comment>> GetAllByRecipeIdAsync(int recipeId)
        {
            return await _dbContext.Comment.Where(c => c.RecipeId == recipeId).ToListAsync();
        }

        public async Task<Comment> UpdateAsync(Comment comment)
        {
            _dbContext.Comment.Update(comment);
            await _dbContext.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment?> GetByIdAsync(int commentId)
        {
            return await _dbContext.Comment.FindAsync(commentId);
        }
    }
}