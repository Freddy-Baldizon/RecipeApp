using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RecipeApp.Domain.Entities;
using RecipeApp.DomainService.Interfaces;
using RecipeApp.Dto;
using RecipeApp.Exceptions;

namespace RecipeApp.Facade.Classes;

public class AuthorizationFacade : IAuthorizationFacade
{
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;

    public AuthorizationFacade(IUserService userService, IConfiguration configuration)
    {
        _userService = userService;
        _configuration = configuration;
    }

    public async Task<AuthorizationResponseDto> AuthorizeAsync(AuthorizationRequestDto request)
    {
        var user = await _userService.GetByEmailAsync(request.Email).ConfigureAwait(false);

        if (user == null || string.IsNullOrEmpty(user.Password) || user.Password != request.Password)
            throw new UnauthorizedResponseException();

        var jwtSection = _configuration.GetSection("Jwt");
        var secret = jwtSection["Secret"];
        if (string.IsNullOrEmpty(secret))
            throw new InvalidOperationException("Jwt:Secret is not configured.");

        var issuer = jwtSection["Issuer"];
        var audience = jwtSection["Audience"];
        var expirationMinutes = int.TryParse(jwtSection["ExpirationMinutes"], out var m) ? m : 60;

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim("id", user.Id.ToString())
        };

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expirationMinutes),
            signingCredentials: creds
        );

        return new AuthorizationResponseDto
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            ExpiresIn = DateTime.UtcNow.AddMinutes(expirationMinutes)
        };
    }
}