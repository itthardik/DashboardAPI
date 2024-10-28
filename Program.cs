using Dashboard.ServiceConfiguration;
using Dashboard.Services;

namespace Dashboard
{
    /// <summary>
    /// Program.cs
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main Endpoint
        /// </summary>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDatabaseContexts(builder.Configuration);
            builder.Services.AddRepositories();
            builder.Services.AddAppServices(builder.Configuration);
            builder.Services.AddHttpClients(builder.Configuration);
            builder.Services.AddHangfireServices(builder.Configuration);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddCustomSwagger();
            builder.Services.AddCustomCors();
            builder.Services.AddCustomAuth(builder.Configuration);


            var app = builder.Build();


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dashboard V1");
                });
            }
            
            app.UseCors("AllowReactApp");
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCustomHangfireJobs();
            app.MapControllers();

            var mqttService = app.Services.GetRequiredService<MqttService>();
            Task.Run(async () =>
            {
                await mqttService.ConnectAsync();
            }).GetAwaiter().GetResult();

            app.Run();
        }
    }
}

