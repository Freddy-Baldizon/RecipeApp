using Microsoft.AspNetCore.Mvc;
using RecipeApp.Api.Mappers;
using RecipeApp.Facade.Interfaces;

namespace RecipeApp.Api.Controllers;

[ApiController]
[Route("/api/country")]
public class CountryController : ControllerBase
{
    private readonly ICountryFacade countryFacade;

    public CountryController(ICountryFacade countryFacade)
    {
        this.countryFacade = countryFacade;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var countries = await countryFacade.GetAllAsync();
        return Ok(CountryMapper.ToModel(countries));
    }

    [HttpGet("/{countryId}")]
    public async Task<IActionResult> GetByIdAsync(string countryId)
    {
        var country = await countryFacade.GetByIdAsync(int.Parse(countryId));
        if (country == null)
        {
            return NotFound("Country not found");
        }

        return Ok(CountryMapper.ToModel(country));
    }
}
