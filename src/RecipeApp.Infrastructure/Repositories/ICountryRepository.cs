using ProyectoSW4.Domain.Entities;
namespace recipeApp.Infrastructure.Repositories
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAllAsync();

        Task<Country?> GetByIdAsync(Guid countryId);

    }
}