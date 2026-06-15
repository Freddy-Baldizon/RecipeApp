using Microsoft.AspNetCore.Mvc;
using RecipeApp.Api.Models.Requests;
using RecipeApp.Domain.Entities;
using RecipeApp.Facade.Interfaces;

namespace RecipeApp.Api.Controllers;

[ApiController]
[Route("/api/user")]
public class UserController(IUserFacade userFacade): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserRequestModel createUser)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public async Task<IActionResult> GetById()
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequestModel updateUser)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("/{userId}")]
    public async Task<IActionResult> DeleteUser(string id)
    {
        throw new NotImplementedException();
    }
}