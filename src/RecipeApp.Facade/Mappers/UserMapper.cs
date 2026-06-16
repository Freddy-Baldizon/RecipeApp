using RecipeApp.Domain.Entities;
using RecipeApp.Dto;
namespace RecipeApp.Facade.Mappers
{
    public class UserMapper
    {
        public static List<UserDto> ToDto(List<User> users)
        {
            return users.Select(p => ToDto(p)).ToList();
        }
        public static UserDto ToDto(User user)
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