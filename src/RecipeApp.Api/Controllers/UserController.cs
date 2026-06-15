using Microsoft.AspNetCore.Mvc;
using RecipeApp.Domain.Entities;
using RecipeApp.Facade.Interfaces;

namespace RecipeApp.Api.Controllers;

[ApiController]
[Route("/api/user")]
public class UserController(IUserFacade userFacade): ControllerBase
{
    [HttpPost]
    public async Task<User> createUserAsync([FromBody] CreateUserRequestModel createUser)
    {
        
    }
}