using Microsoft.OpenApi.Models;

namespace Dashboard.ServiceConfiguration
{
    /// <summary>
    /// Extension methods for configuring Swagger services.
    /// </summary>
    public static class SwaggerServiceExtensions
    {
        /// <summary>
        /// Configures Swagger services with XML comments for class and function-level documentation.
        /// </summary>
        /// <param name="services">The service collection to which Swagger will be added.</param>
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Dashboard API",
                    Version = "v1"
                });

                var xmlFile = "dashboard.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(xmlPath, includeControllerXmlComments: false);
            });

            return services;
        }
    }

}
