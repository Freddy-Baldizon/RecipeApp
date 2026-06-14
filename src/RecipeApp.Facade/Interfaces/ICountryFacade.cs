using RecipeApp.Domain.Entities;
using RecipeApp.Dto;

namespace RecipeApp.Facade.Interfaces
{
    public interface ICountryFacade
    {
        Task<List<CountryDto>> GetAllAsync();

        Task<CountryDto?> GetByIdAsync(int countryId);
    }
}