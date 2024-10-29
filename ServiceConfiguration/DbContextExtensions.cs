using Dashboard.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.ServiceConfiguration
{
    /// <summary>
    /// Extension methods for configuring database contexts.
    /// </summary>
    public static class DbContextExtensions
    {
        /// <summary>
        /// Configures the application's database contexts.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static IServiceCollection AddDatabaseContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApiContext>(options =>
                options.UseSqlServer(configuration["ConnectionStrings:ApiContext"]));

            return services;
        }
    }

}
