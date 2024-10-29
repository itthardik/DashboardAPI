namespace Dashboard.ServiceConfiguration
{
    /// <summary>
    /// Extension methods for configuring CORS services.
    /// </summary>
    public static class CorsServiceExtensions
    {
        /// <summary>
        /// Configures CORS policies for the application.
        /// </summary>
        /// <param name="services">The service collection to which CORS will be added.</param>
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection AddCustomCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp", builder =>
                {
                    builder.WithOrigins("http://localhost:3000")
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials();
                });
            });

            return services;
        }
    }
}
