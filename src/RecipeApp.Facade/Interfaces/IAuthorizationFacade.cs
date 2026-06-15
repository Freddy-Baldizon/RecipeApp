using RecipeApp.Dto;

namespace RecipeApp.Facade;

public interface IAuthorizationFacade
{
    Task<AuthorizationResponseDto> AuthorizeAsync(AuthorizationRequestDto request);
}