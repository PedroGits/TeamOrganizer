using AuthManager.DTOs;
using AuthManager.Services.Interfaces;
using AuthManager.Services;
using AuthManager.Configurations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddHttpClient();
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
builder.Services.AddScoped<IJWTService, JWTService>();

var app = builder.Build();

app.MapPost("/login", async (LoginRequest request, IHttpClientFactory clientFactory, IJWTService tokenService) =>
{
    var client = clientFactory.CreateClient();
    var userResponse = await client.GetAsync($"UserManagerApi/users/validate?username={request.Email}&password={request.Password}");

    if (!userResponse.IsSuccessStatusCode)
    {
        return Results.Unauthorized();
    }

    var userResponseContent = await userResponse.Content.ReadAsStringAsync();
    var role = userResponseContent;

    var token = tokenService.GenerateToken(request.Email, role);
    return Results.Ok(new { Token = token });
});

app.Run();
