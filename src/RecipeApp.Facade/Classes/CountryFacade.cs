using System;
using System.Linq.Expressions;
using System.Net.Mime;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using RecipeApp.DomainService.Interfaces;
using RecipeApp.Dto;
using RecipeApp.Exceptions;
using RecipeApp.Facade.Interfaces;
using RecipeApp.Facade.Mappers;

namespace StoreBackend.Facade;

public class CountryFacade : ICountryFacade
{
    private readonly ICountryService countryService;

    public CountryFacade(ICountryService countryService)
    {
        this.countryService = countryService;
    }

    public async Task<List<CountryDto>> GetAllAsync()
    {
        var entities = await countryService.GetAllAsync();
        return CountryMapper.ToDto(entities);
    }

    public async Task<CountryDto?> GetByIdAsync(int countryId)
    {
        var entity = await countryService.GetByIdAsync(countryId);
        if (entity == null) throw new ResourceNotFoundException();
        return CountryMapper.ToDto(entity);
    }
}

