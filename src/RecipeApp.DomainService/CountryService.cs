using RecipeApp.Domain.Entities;
using RecipeApp.Infrastructure.Repositories;
using RecipeApp.Exceptions;
using RecipeApp.Dto;

namespace RecipeApp.DomainService;

public class CountryService : ICountryService
{
    private readonly ICountryRepository _countryRepository;

    public CountryService(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<Country?> GetByIdAsync(int countryId)
    {
        var country = await _countryRepository.GetByIdAsync(countryId);
        if (country == null)
        {
            throw new ResourceNotFoundException($"Country with ID {countryId} not found.");
        }
        return country;
    }

    public async Task<List<Country>> GetAllAsync()
    {
        return await _countryRepository.GetAllAsync();
    }
}