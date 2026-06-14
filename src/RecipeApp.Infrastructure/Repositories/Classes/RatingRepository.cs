using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RecipeApp.Domain.Entities;
using RecipeApp.Infrastructure.Repositories.Interfaces;

namespace RecipeApp.Infrastructure.Repositories.Classes
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

        public async Task<List<Rating>> GetRatingByUserId(int userId)
        {
            return await _dbContext.Rating
                .Where(r => r.UserId == userId)
                .ToListAsync();
        }

        public async Task<Rating> UpdateAsync(Rating rating)
        {
            _dbContext.Rating.Update(rating);
            await _dbContext.SaveChangesAsync();
            return rating;
        }

        public async Task<List<Rating>> GetRatingByRecipeId(int recipeId)
        {
            return await _dbContext.Rating
                .Where(r => r.RecipeId == recipeId)
                .ToListAsync();
        }

        public async Task DeleteAsync(Rating rating)
        {
            _dbContext.Rating.Remove(rating);
            await _dbContext.SaveChangesAsync();
        }
    }
}