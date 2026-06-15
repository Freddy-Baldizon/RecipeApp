using RecipeApp.Api.Models.Requests;
using RecipeApp.Api.Models.Responses;
using RecipeApp.Dto;
using RecipeApp.Domain.Entities;

namespace RecipeApp.Api.Mappers
{
    public class UserMapper
    {
        public static CreateUserDto ToDto(CreateUserRequestModel userRequestModel)
        {
            return new CreateUserDto
            {
                Email = userRequestModel.Email,
                Username = userRequestModel.Username,
                Password = userRequestModel.Password,
                Avatar = userRequestModel.Avatar
            };
        }

        public static List<UserResponseModel> ToModel(List<UserDto> users)
        {
            return users.Select(u => ToModel(u)).ToList();
        }

        public static UserResponseModel ToModel(UserDto user)
        {
            return new UserResponseModel
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.Username,
                Avatar = user.Avatar
            };
        }

        public static UpdateUserDto ToDto(UpdateUserRequestModel updateUserRequestModel)
        {
            return new UpdateUserDto
            {
                Username = updateUserRequestModel.Username,
                Avatar = updateUserRequestModel.Avatar,
                Password = updateUserRequestModel.Password
            };
        }
    }
}
           