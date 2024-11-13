using AuthManager.DTOs;
using AuthManager.Services.Interfaces;
using AuthManager.Services;
using AuthManager.Configurations;
using AuthManager.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddHttpClient();
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
builder.Services.AddScoped<IJWTService, JWTService>();
builder.Services.AddScoped<IValidateUser, ValidateUser>();
builder.Services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
var app = builder.Build();

app.MapPost("/login", async (LoginRequest request, IValidator <LoginRequest> validator, IHttpClientFactory clientFactory, IJWTService tokenService, IValidateUser validateUser) =>
{
    ValidationResult validationResult = await validator.ValidateAsync(request);
    
    if (!validationResult.IsValid)
    {
        return Results.BadRequest(validationResult.Errors);
    }
    
    var userResponse = await validateUser.ValidateUserLogin(request.Email, request.Password);

    if (!userResponse.IsValid || string.IsNullOrEmpty(userResponse.Role))
        return Results.Unauthorized();

    var token = tokenService.GenerateToken(request.Email, userResponse.Role);
    return Results.Ok(new { Token = token });
});

app.Run();
