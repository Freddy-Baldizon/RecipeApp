using System;
using RecipeApp.Domain.Entities;

namespace RecipeApp.Infrastructure.Repositories

{
    public class RatingRepository : IRatingRepository
    {
        private readonly AppDbContext _dbContext;

        public RatingRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Rating> GetByIdAsync(Guid id)
        {
            return await _dbContext.Rating.FindAsync(id);
        }

        public async Task AddAsync(Rating rating)
        {
            await _dbContext.Rating.AddAsync(rating);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var rating = await _dbContext.Rating.FindAsync(id);
            if (rating != null)
            {
                _dbContext.Rating.Remove(rating);
                await _dbContext.SaveChangesAsync();
            }
        }

        Task IRatingRepository.DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}