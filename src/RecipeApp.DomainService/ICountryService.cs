using RecipeApp.Domain.Entities;
using RecipeApp.Dto;

namespace RecipeApp.DomainService
{
    public interface ICountryService
    {
        Task<List<Country>> GetAllAsync();

        Task<Country?> GetByIdAsync(int countryId);
    }
}