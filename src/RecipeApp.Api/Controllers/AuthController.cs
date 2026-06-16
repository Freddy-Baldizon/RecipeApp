using Microsoft.AspNetCore.Mvc;
using RecipeApp.Api.Mappers;
using RecipeApp.Api.Models.Requests;
using RecipeApp.Facade;

namespace RecipeApp.Api.Controllers;

[ApiController]
[Route("/api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthorizationFacade authorizationFacade;

    public AuthController(IAuthorizationFacade authorizationFacade)
    {
        this.authorizationFacade = authorizationFacade;
    }

    [HttpPost]
    public async Task<IActionResult> AuthorizeAsync([FromBody] AuthorizationRequestModel request)
    {
        var responseDto = await authorizationFacade.AuthorizeAsync(request.ToDto());
        return Ok(responseDto.ToResponse());
    }
}
