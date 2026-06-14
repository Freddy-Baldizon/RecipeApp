using RecipeApp.Domain.Entities;
namespace RecipeApp.Infrastructure.Repositories.Interfaces
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAllAsync();

        Task<Country?> GetByIdAsync(int countryId);

    }
}