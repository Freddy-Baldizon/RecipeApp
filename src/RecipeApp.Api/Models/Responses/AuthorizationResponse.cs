using System;

namespace RecipeApp.Api.Models.Responses;

public class AuthorizationResponse
{
    public required string Token { get; set; }
    public required DateTime ExpiresIn { get; set; }
}