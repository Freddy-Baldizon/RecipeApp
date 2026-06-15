using RecipeApp.Domain.Entities;
using RecipeApp.Dto;
namespace RecipeApp.Facade.Mappers
{
    public class UserMapper
    {
        public static List<UserDto> ToDto(List<UserDto> users)
        {
            return users.Select(p => ToDto(p)).ToList();
        }
        public static UserDto ToDto(UserDto user)
        {
            return new UserDto
            {
               Id = user.Id,
               Username = user.Username,
               Avatar = user.Avatar,
               Email = user.Email
            };
        }
    }
}