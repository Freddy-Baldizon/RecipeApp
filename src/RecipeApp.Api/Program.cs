using System.Text;
using System.Text.Json.Serialization;
using System.Threading.RateLimiting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RecipeApp.Api.Filter;
using RecipeApp.Api.Security;
using RecipeApp.DomainService;
using RecipeApp.DomainService.Classes;
using RecipeApp.DomainService.Interfaces;
using RecipeApp.Facade;
using RecipeApp.Facade.Interfaces;
using RecipeApp.Facade.Classes;
using RecipeApp.Infrastructure;
using RecipeApp.Infrastructure.Repositories;
using RecipeApp.Infrastructure.Repositories.Interfaces;
using RecipeApp.Infrastructure.Repositories.Classes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<MessageExceptionFilter>();
})
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// var allowedOrigins = builder.Configuration
//     .GetSection("Cors:AllowedOrigins")
//     .Get<string[]>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowedOriginsPolicy", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var jwtSettings = builder.Configuration.GetSection("Jwt");

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings["Secret"] ?? throw new InvalidOperationException("Jwt:Secret is not configured.")))
        };
    });

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
builder.Services.AddScoped<IFavoriteRepository, FavoriteRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

// Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IIngredientService, IngredientService>();
builder.Services.AddScoped<IFavoriteService, FavoriteService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<ICommentService, CommentService>();

// Facades
builder.Services.AddScoped<IUserFacade, UserFacade>();
builder.Services.AddScoped<IRecipeFacade, RecipeFacade>();
builder.Services.AddScoped<IIngredientFacade, IngredientFacade>();
builder.Services.AddScoped<IFavoriteFacade, FavoriteFacade>();
builder.Services.AddScoped<ICountryFacade, CountryFacade>();
builder.Services.AddScoped<ICommentFacade, CommentFacade>();
builder.Services.AddScoped<IAuthorizationFacade, AuthorizationFacade>();

// builder.Services.AddAuthorization(options =>
// {
//     options.AddPolicy(AuthorizationPolicies.CanSearchUsers, policy =>
//        policy.RequireRole(
//            "Administrator",
//            "Support"
//        ));
// });

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var permitLimit = builder.Configuration.GetValue<int>("RateLimiting:PermitLimit");
var windowSeconds = builder.Configuration.GetValue<int>("RateLimiting:WindowSeconds");
var queueLimit = builder.Configuration.GetValue<int>("RateLimiting:QueueLimit");

builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("fixed", limiterOptions =>
    {
        limiterOptions.PermitLimit = permitLimit;
        limiterOptions.Window = TimeSpan.FromSeconds(windowSeconds);
        limiterOptions.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        limiterOptions.QueueLimit = queueLimit;
    });
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
    options.OnRejected = async (context, token) =>
    {
        context.HttpContext.Response.ContentType = "application/json";
        await context.HttpContext.Response.WriteAsync(
"""{"status":429,"message":"Demasiadas solicitudes. Intente nuevamente más tarde."}""",
cancellationToken: token
);
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// app.UseHttpsRedirection();

app.UseCors("AllowedOriginsPolicy");

app.UseAuthentication();

app.UseRateLimiter();

app.UseAuthorization();

app.UseRateLimiter();

app.MapControllers().RequireRateLimiting("fixed");

app.Run();

