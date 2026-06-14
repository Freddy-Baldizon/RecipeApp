using Microsoft.EntityFrameworkCore;
using RecipeApp.Domain.Entities;
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
            List<Favorite> results = await _dbContext.Favorite.Where(f => f.UserId == userId).ToListAsync();
            return results;
        }

        public async Task DeleteAsync(Favorite favorite)
        {
            _dbContext.Favorite.Remove(favorite);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Favorite> AddAsync(Favorite favorite)
        {
            await _dbContext.Favorite.AddAsync(favorite);
            await _dbContext.SaveChangesAsync();
            return favorite;
        }

        public async Task<Favorite?> GetFavoriteByIdAsync(int userId)
        {
            return await _dbContext.Favorite.FindAsync(userId);
        }
    }
}