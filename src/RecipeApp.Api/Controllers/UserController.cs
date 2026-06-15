using Microsoft.AspNetCore.Mvc;
using RecipeApp.Domain.Entities;
using RecipeApp.Facade.Interfaces;

namespace RecipeApp.Api.Controllers;

[ApiController]
[Route("/api/user")]
public class UserController(IUserFacade userFacade): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> createUserAsync([FromBody] CreateUserRequestModel createUser)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public async Task<IActionResult> getAllAsync()
    {
        throw new NotImplementedException();
    }
}