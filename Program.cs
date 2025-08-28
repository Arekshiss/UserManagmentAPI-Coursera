using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyApp.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

// ------------------------------
// 🔧 Services Configuration
// ------------------------------

// Add controllers
builder.Services.AddControllers();

// Custom model validation response
builder.Services.ConfigureCustomValidationResponse();

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// MongoDB settings binding
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));

// MongoDB service
builder.Services.AddSingleton<MongoDbService>();

// ------------------------------
// 🏗 Build the app
// ------------------------------
var app = builder.Build();

// ------------------------------
// Middleware Pipeline
// ------------------------------

// 1️⃣ Exception handling first
app.UseMiddleware<ExceptionHandlingMiddleware>();

// 2️⃣ HTTPS redirection
app.UseHttpsRedirection();

// 3️⃣ Request logging
app.UseMiddleware<RequestLoggingMiddleware>();

// 4️⃣ Routing
app.UseRouting();

// 5️⃣ Token validation before authorization
var validToken = builder.Configuration["Auth:Token"] ?? "my-super-secret-token";
var publicPaths = new[]
{
    "/",             // base route
    "/api/auth/login",
    "/swagger",
    "/swagger/index.html",
    "/swagger/v1/swagger.json"
};
app.UseMiddleware<TokenValidationMiddleware>(validToken, publicPaths);

// 6️⃣ Authorization
app.UseAuthorization();

// 7️⃣ Swagger (development only)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 8️⃣ Map endpoints
app.MapGet("/", () => "User Management API is running.");
app.MapGet("/public/info", () => "Public Info"); // Public endpoint
app.MapControllers();

// ------------------------------
// Run the app
// ------------------------------
app.Run();
