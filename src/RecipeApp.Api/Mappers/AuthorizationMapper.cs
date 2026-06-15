using RecipeApp.Api.Models.Requests;
using RecipeApp.Api.Models.Responses;
using RecipeApp.Dto;

namespace RecipeApp.Api.Mappers;

public static class AuthorizationMapper
{
    public static AuthorizationRequestDto ToDto(this AuthorizationRequestModel model)
    {
        return new AuthorizationRequestDto
        {
            Email = model.Email,
            Password = model.Password,
        };
    }

    public static AuthorizationResponse ToResponse(this AuthorizationResponseDto dto)
    {
        return new AuthorizationResponse
        {
            Token = dto.Token,
            ExpiresIn = dto.ExpiresIn,
        };
    }
}