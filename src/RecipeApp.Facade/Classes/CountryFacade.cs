using RecipeApp.DomainService.Interfaces;
using RecipeApp.Dto;
using RecipeApp.Exceptions;
using RecipeApp.Facade.Interfaces;
using RecipeApp.Facade.Mappers;

namespace RecipeApp.Facade;

public class CountryFacade : ICountryFacade
{
    private readonly ICountryService countryService;

    public CountryFacade(ICountryService countryService)
    {
        this.countryService = countryService;
    }

    public async Task<List<CountryDto>> GetAllAsync()
    {
        var countries = await countryService.GetAllAsync();
        return CountryMapper.ToDto(countries);
    }

    public async Task<CountryDto?> GetByIdAsync(int countryId)
    {
        var entity = await countryService.GetByIdAsync(countryId);
        if (entity == null) throw new ResourceNotFoundException();
        return CountryMapper.ToDto(entity);
    }
}

