using RecipeApp.Api.Models.Requests;
using RecipeApp.Api.Models.Responses;
using RecipeApp.Dto;

namespace RecipeApp.Api.Mappers
{
    public class RecipeMapper
    {
        public static RecipeDto ToDto(CreateRecipeRequestModel recipeRequestModel)
        {
            foreach (var item in recipeRequestModel.RecipeIngredientsDto)
            {
                Console.WriteLine(item.IngredientId);
            }
            return new RecipeDto
            {
                Name = recipeRequestModel.Name,
                Description = recipeRequestModel.Description,
                CountryId = recipeRequestModel.CountryId,
                UserId = recipeRequestModel.UserId,
                PhotoUrl = recipeRequestModel.PhotoUrl,
                Ingredients = recipeRequestModel.RecipeIngredientsDto
            };
        }

        public static List<RecipeResponseModel> ToModel(List<RecipeDto> recipeDtos)
        {
            return recipeDtos.Select(r => ToModel(r)).ToList();
        }

        public static RecipeResponseModel ToModel(RecipeDto recipeDto)
        {
            return new RecipeResponseModel
            {
                Id = recipeDto.Id,
                Name = recipeDto.Name,
                Description = recipeDto.Description,
                CountryId = recipeDto.CountryId,
                CountryName = recipeDto.CountryName,
                CountryFlag = recipeDto.CountryFlag,
                UserId = recipeDto.UserId,
                Username = recipeDto.Username,
                PhotoUrl = recipeDto.PhotoUrl,
                Ingredients = recipeDto.Ingredients,
                Comments = recipeDto.Comments.Where(c => c is not null).Select(c => CommentMapper.ToModel(c!)).ToList()
            };
        }


        public static UpdateRecipeDto ToDto(UpdateRecipeRequestModel updateRecipeRequestModel)
        {
            return new UpdateRecipeDto
            {
                Name = updateRecipeRequestModel.Name,
                Description = updateRecipeRequestModel.Description,
                CountryId = updateRecipeRequestModel.CountryId,
                PhotoUrl = updateRecipeRequestModel.PhotoUrl
            };
        }

        
    }
}