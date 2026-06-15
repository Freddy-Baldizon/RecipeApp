using RecipeApp.Api.Models.Requests;
using RecipeApp.Api.Models.Responses;
using RecipeApp.Dto;

namespace RecipeApp.Api.Mappers
{
    public class CountryMapper
    {
  
        public static List<CountryResponseModel> ToModel(List<CountryDto> countryDto)
        {
            return countryDto.Select(c => ToModel(c)).ToList();
        }
        
        public static CountryResponseModel ToModel(CountryDto countryDto)
        {
            return new CountryResponseModel
            {
                Id = countryDto.Id,
                Name = countryDto.Name,
                FlagUrl = countryDto.FlagUrl,
                IsoAlpha3 = countryDto.IsoAlpha3
            };
        }
    }
}