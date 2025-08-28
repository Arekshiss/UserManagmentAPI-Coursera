using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyApp.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

// ------------------------------
// Services
// ------------------------------
builder.Services.AddControllers();

// Custom validation response
builder.Services.ConfigureCustomValidationResponse();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// MongoDB settings
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));
builder.Services.AddSingleton<MongoDbService>();

// JWT Authentication
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = JwtHelper.GetTokenValidationParameters(builder.Configuration);
    });

builder.Services.AddAuthorization();

// ------------------------------
// Build app
// ------------------------------
var app = builder.Build();

// ------------------------------
// Middleware pipeline
// ------------------------------

// 1️⃣ Exception handling
app.UseMiddleware<ExceptionHandlingMiddleware>();

// 2️⃣ HTTPS redirection
app.UseHttpsRedirection();

// 3️⃣ Swagger (development only)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 4️⃣ Request logging
app.UseMiddleware<RequestLoggingMiddleware>();

// 5️⃣ Routing
app.UseRouting();

// 6️⃣ Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

// 7️⃣ Token validation (with public routes)
var publicPaths = new[]
{
    "/", 
    "/api/auth/login",
    "/api/auth/register",
    "/swagger",
    "/swagger/index.html",
    "/swagger/v1/swagger.json",
    "/public/info"
};

app.Use(async (context, next) =>
{
    var logger = context.RequestServices.GetRequiredService<ILogger<TokenValidationMiddleware>>();
    var middleware = new TokenValidationMiddleware(next, logger, publicPaths);
    await middleware.InvokeAsync(context);
});

// 8️⃣ Map endpoints
app.MapGet("/", () => "User Management API is running.");
app.MapGet("/public/info", () => "Public Info");
app.MapControllers();

// ------------------------------
// Run app
// ------------------------------
app.Run();
