using Microsoft.AspNetCore.Mvc;
using RecipeApp.Api.Mappers;
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
        var requestDto = UserMapper.ToDto(createUser);
        var userDto = await userFacade.AddAsync(requestDto);
        var userModel = UserMapper.ToModel(userDto);
        return Created("",userModel);

    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var allUsers = await userFacade.GetAllAsync();
        var allUsersModel = UserMapper.ToModel(allUsers);
        return Ok(allUsersModel);
    }

    [HttpGet("/{userId}")]
    public async Task<IActionResult> GetById(string userId)
    {
        var user = await userFacade.GetByIdAsync(int.Parse(userId));
        if(user == null)
        {
            return NotFound("User not found");
        }
        var userModel = UserMapper.ToModel(user);
        return Ok(userModel);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequestModel updateUser)
    {
        var updateRequest = UserMapper.ToDto(updateUser);
        var updatedUser = await userFacade.UpdateAsync(updateRequest);
    }

    [HttpDelete("/{userId}")]
    public async Task<IActionResult> DeleteUser(string id)
    {
        throw new NotImplementedException();
    }
}