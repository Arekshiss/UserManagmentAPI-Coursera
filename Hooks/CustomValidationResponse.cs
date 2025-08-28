using Microsoft.AspNetCore.Mvc;

namespace MyApp.Api.Configuration
{
    public static class ApiBehaviorConfig
    {
        /// <summary>
        /// Configures the service collection to use a custom factory for generating
        /// responses to invalid model state. The factory is used to generate a
        /// 400 Bad Request response with a JSON body containing the validation errors.
        /// </summary>
        /// <param name="services">The service collection to configure.</param>
        public static void ConfigureCustomValidationResponse(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState
                    .Where(ms => ms.Value?.Errors.Count > 0)
                    .ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray()
                    );
                    return new BadRequestObjectResult(errors);
                };
            });
        }
    }
}
