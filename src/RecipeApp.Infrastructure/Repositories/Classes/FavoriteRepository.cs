using Microsoft.EntityFrameworkCore;
using RecipeApp.Domain.Entities;
using RecipeApp.Exceptions;
using RecipeApp.Infrastructure.Repositories.Interfaces;

namespace RecipeApp.Infrastructure.Repositories.Classes
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly AppDbContext _dbContext;

        public FavoriteRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Favorite>> GetByUserAsync(int userId)
        {
            return await _dbContext.Favorite
                .Where(f => f.UserId == userId)
                .Include(f => f.Recipe).ThenInclude(r => r.Country)
                .Include(f => f.Recipe).ThenInclude(r => r.User)
                .ToListAsync();
        }

        public async Task<Favorite?> GetFavoriteAsync(int userId, int recipeId)
        {
            return await _dbContext.Favorite.FindAsync(userId, recipeId);
        }

        public async Task<Favorite> AddAsync(Favorite favorite)
        {
            try
            {
                await _dbContext.Favorite.AddAsync(favorite);
                await _dbContext.SaveChangesAsync();
                return favorite;
            }
            catch (DbUpdateException)
            {
                throw new DuplicateResourceException($"Recipe {favorite.RecipeId} is already in favorites for user {favorite.UserId}.");
            }
        }

        public async Task DeleteAsync(Favorite favorite)
        {
            _dbContext.Favorite.Remove(favorite);
            await _dbContext.SaveChangesAsync();
        }
    }
}