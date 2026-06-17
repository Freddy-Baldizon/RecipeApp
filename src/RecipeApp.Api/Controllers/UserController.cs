using Microsoft.AspNetCore.Mvc;
using RecipeApp.Api.Mappers;
using RecipeApp.Api.Models.Requests;
using RecipeApp.Domain.Entities;
using RecipeApp.Exceptions;
using RecipeApp.Facade.Interfaces;

namespace RecipeApp.Api.Controllers;

[ApiController]
[Route("/api/user")]
public class UserController(IUserFacade userFacade): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserRequestModel createUser)
    {
        var dto = UserMapper.ToDto(createUser);
        var userDto = await userFacade.AddAsync(dto);
        var userModel = UserMapper.ToModel(userDto);
        return Created("",userModel);

    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestModel loginInfo)
    {
        var dto = new Dto.LoginRequestDto { Email = loginInfo.Email, Password = loginInfo.Password };
        
        try
        {
            var response = await userFacade.LoginAsync(dto);
            return Ok(response);
        } 
        catch (UnauthorizedResponseException error)
        {
            return Unauthorized(error.Message);
        }

    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var allUsers = await userFacade.GetAllAsync();
        var allUsersModel = UserMapper.ToModel(allUsers);
        return Ok(allUsersModel);
    }

    [HttpGet("{userId:int}")]
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

    [HttpPut("{userId}")]
    public async Task<IActionResult> UpdateUser(string userId,[FromBody] UpdateUserRequestModel model)
    {
        var requestDto = UserMapper.ToDto(model);
        var updatedUser = await userFacade.UpdateAsync(int.Parse(userId),requestDto);
        var responseModel = UserMapper.ToModel(updatedUser);
        return Ok(responseModel);
    }

    [HttpDelete("{userId}")]
    public async Task<IActionResult> DeleteUser(string id)
    {
        await userFacade.DeleteAsync(int.Parse(id));
        return Ok();
    }
}