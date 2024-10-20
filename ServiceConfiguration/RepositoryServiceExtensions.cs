using Dashboard.Repository.Interfaces;
using Dashboard.Repository;

namespace Dashboard.ServiceConfiguration
{
    /// <summary>
    /// Repository Service Extensions Static Class
    /// </summary>
    public static class RepositoryServiceExtensions
    {
        /// <summary>
        /// Add all repos to service collection
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IRevenueRepository, RevenueRepository>();

            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<IAlertRepository, AlertRepository>();

            services.AddScoped<ISalesRepository, SalesRepository>();

            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }

}
