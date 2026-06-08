using System;
using RecipeApp.Domain.Entities;

namespace RecipeApp.Infrastructure.Repositories

{
    public class RatingRepository : IRatingRepository
    {
        private readonly RecipeAppDbContext _dbContext;

        public RatingRepository(RecipeAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Rating> GetByIdAsync(Guid id)
        {
            return await _dbContext.Ratings.FindAsync(id);
        }

        public async Task AddAsync(Rating rating)
        {
            await _dbContext.Ratings.AddAsync(rating);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var rating = await _dbContext.Ratings.FindAsync(id);
            if (rating != null)
            {
                _dbContext.Ratings.Remove(rating);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}