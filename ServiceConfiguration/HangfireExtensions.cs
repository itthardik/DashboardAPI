using Dashboard.Services;
using Hangfire;

namespace Dashboard.ServiceConfiguration
{
    /// <summary>
    /// Extension methods for configuring Hangfire services.
    /// </summary>
    public static class HangfireExtensions
    {
        /// <summary>
        /// Configures Hangfire with SQL Server storage and adds a Hangfire server.
        /// </summary>
        /// <param name="services">The service collection to which Hangfire will be added.</param>
        /// <param name="configuration">The configuration object used to retrieve the connection string.</param>
        public static IServiceCollection AddHangfireServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHangfire(x => x.UseSqlServerStorage(configuration["ConnectionStrings:ApiContext"]));

            services.AddHangfireServer();

            return services;
        }

        /// <summary>
        /// Configures recurring jobs for the application.
        /// </summary>
        /// <param name="app">The application builder to which the jobs will be added.</param>
        public static void UseCustomHangfireJobs(this IApplicationBuilder app)
        {
            app.UseHangfireDashboard();

            RecurringJob.AddOrUpdate<BackgroundJobService>(
                "midnight-restock-job",
                service => service.RestockBasedOnNotification(),
                Cron.Daily);
            RecurringJob.AddOrUpdate<BackgroundJobService>(
                "avg-daily-usage-update-job",
                service => service.UpdateAverageDailyUsageAndReorderPointForAllProducts(),
                Cron.Daily);
            RecurringJob.AddOrUpdate<BackgroundJobService>(
                "get-overall-sales-each-5sec",
                service => service.GetTotalOrderInLast60Sec(),
                Cron.Minutely);
        }
    }

}
