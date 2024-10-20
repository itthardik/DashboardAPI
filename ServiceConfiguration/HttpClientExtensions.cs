namespace Dashboard.ServiceConfiguration
{
    using Dashboard.Services.Interfaces;
    using Dashboard.Services;
    using System.Net.Http.Headers;
    using System.Text;

    /// <summary>
    /// Extension methods for configuring HTTP clients.
    /// </summary>
    public static class HttpClientExtensions
    {
        /// <summary>
        /// Configures HTTP clients for the application.
        /// </summary>
        ///<param name="configuration"></param>
        ///<param name="services"></param>
        public static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IFreshdeskService, FreshdeskService>(client =>
            {
                client.BaseAddress = new Uri("https://hardikintimetec.freshdesk.com/api/v2/");

                var apiKey = configuration["FreshDesk:ApiKey"];
                var authToken = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{apiKey}:X"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);

                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            return services;
        }
    }

}
