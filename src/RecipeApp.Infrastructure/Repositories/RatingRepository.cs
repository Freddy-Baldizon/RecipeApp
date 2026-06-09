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

        public async Task<Rating> GetByIdAsync(int id)
        {
            return await _dbContext.Rating.FindAsync(id);
        }

        public async Task<Rating> AddAsync(Rating rating)
        {
            await _dbContext.Rating.AddAsync(rating);
            return rating;  
        }

        public async Task DeleteAsync(int id)
        {
            var rating = await _dbContext.Rating.FindAsync(id);
            if (rating != null)
            {
                _dbContext.Rating.Remove(rating);
                await _dbContext.SaveChangesAsync();
            }
        }

        Task IRatingRepository.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}