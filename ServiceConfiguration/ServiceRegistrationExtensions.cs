using Dashboard.Services.Interfaces;
using Dashboard.Services;
using Microsoft.Extensions.Configuration;

namespace Dashboard.ServiceConfiguration
{
    /// <summary>
    /// Extension methods for registering application services.
    /// </summary>
    public static class ServiceRegistrationExtensions
    {
        /// <summary>
        /// Adds application services to the service collection.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<BrokerService>();

            services.AddSingleton(_ => new MqttService(configuration));

            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IRevenueService, RevenueService>();

            services.AddScoped<ISalesService, SalesService>();

            services.AddScoped<IAlertService, AlertService>();

            services.AddScoped<IFreshdeskService, FreshdeskService>();

            services.AddScoped<IInventoryService, InventoryService>();

            services.AddScoped<IOrderService, OrderService>();

            return services;
        }
    }

}
