using RecipeApp.Domain.Entities;
using RecipeApp.Dto;

namespace RecipeApp.DomainService.Interfaces
{
    public interface ICountryService
    {
        Task<List<Country>> GetAllAsync();
        Task<Country?> GetByIdAsync(int countryId);
    }
}