using Microsoft.AspNetCore.Mvc;
using RecipeApp.Domain.Entities;
using RecipeApp.Facade.Interfaces;

namespace RecipeApp.Api.Controllers;

[ApiController]
public class UserController(IUserFacade userFacade): ControllerBase
{
    [HttpPost]
    public async Task<User> createUser([FromBody] CreateUserRequestModel createUser){}
}