using Microsoft.EntityFrameworkCore;
using RecipeApp.Domain.Entities;
namespace RecipeApp.Infrastructure.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AppDbContext _dbContext;
        public async Task<List<Country>> GetAllAsync()
        {
            return await _dbContext.Country.ToListAsync();
        }

        public async Task<Country?> GetByIdAsync(int countryId)
        {
            return await _dbContext.Country.FindAsync(countryId);
        }
    }
}