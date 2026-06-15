namespace RecipeApp.Api.Security;

public static class AuthorizationPolicies
{
    public const string CanManageUsers = "CanManageUsers";
    public const string CanManageRecipes = "CanManageRecipes";
    public const string CanManageComments = "CanManageComments";
}