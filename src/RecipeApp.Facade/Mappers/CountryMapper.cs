using RecipeApp.Domain.Entities;
using RecipeApp.Dto;
namespace RecipeApp.Facade.Mappers;

    public class CountryMapper
    {
        public static List<CountryDto> ToDto(List<CountryDto> countries)
        {
            return countries.Select(p => ToDto(p)).ToList();
        }
        public static CountryDto ToDto(CountryDto country)
        {
            return new CountryDto
            {
                Id = country.Id,
                Name = country.Name,
                FlagUrl = country.FlagUrl,
                IsoAlpha3 = country.IsoAlpha3
            };
        }
    }
