
//dotnet ef dbcontext scaffold "Name=ApiContext" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models --context-dir DataContext --context ApiContext --force

using Dashboard.DataContext;
using Dashboard.Repository.Interfaces;
using Dashboard.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Dashboard.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using Hangfire;

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
        /// <param name="args"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            IConfiguration configuration = builder.Configuration;

            // Add services to the container.
            builder.Services.AddDbContext<ApiContext>(options =>
                options.UseSqlServer(configuration["ConnectionStrings:ApiContext"] ));

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IRevenueRepository, RevenueRepository>();
            builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IAlertRepository, AlertRepository>();

            builder.Services.AddTransient<BrokerService>();

            builder.Services.AddControllers();

            builder.Services.AddHangfire(x => x.UseSqlServerStorage(configuration["ConnectionStrings:ApiContext"]));
            builder.Services.AddHangfireServer();

            builder.Services.AddSignalR();
            builder.Services.AddSingleton<MqttService>(serviceProvider =>
            {
                var hubContext = serviceProvider.GetRequiredService<IHubContext<MqttHub>>();
                return new MqttService(hubContext, serviceProvider);
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Dashboard API", Version = "v1" });

                var xmlFile = "dashboard.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000")
                               .AllowAnyHeader()
                               .AllowAnyMethod()
                               .AllowCredentials();
                    });
            });

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Secret"] ?? throw new InvalidOperationException("JWT 'Secret' not found."))),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    var token = context.Request.Cookies["jwtToken"];
                    if (!string.IsNullOrEmpty(token))
                    {
                        context.Token = token;
                    }

                    return Task.CompletedTask;
                }
            };
            });
            builder.Services.AddAuthorizationBuilder()
                .AddPolicy("FullAccessPolicy", policy =>
                    policy.RequireRole("admin"))
                .AddPolicy("RevenueAccessPolicy", policy =>
                    policy.RequireRole("revenue","admin")
                    )
                .AddPolicy("InventoryAccessPolicy", policy =>
                    policy.RequireRole("inventory", "admin")
                    );


            var app = builder.Build();

            app.UseCors("AllowReactApp");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dashboard V1");
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapHub<MqttHub>("/mqtthub");

            var mqttService = app.Services.GetRequiredService<MqttService>();

            Task.Run(async () =>
            {
                await mqttService.ConnectAsync();
            }).GetAwaiter().GetResult();


            app.MapControllers();

            app.UseHangfireDashboard();

            RecurringJob.AddOrUpdate<BackgroundJobService>(
                "midnight-restock-job",
                service => service.RestockBasedOnNotification(),
                Cron.Daily);
            RecurringJob.AddOrUpdate<BackgroundJobService>(
                "daily-usage-update-job",
                service => service.UpdateAverageDailyUsageAndReorderPointForAllProducts(),
                Cron.Daily);

            app.MapPost("/start-job", async (IBackgroundJobClient backgroundJobClient) =>
            {
                string excelFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Orders.xlsx"); ; // Update this path

                // Enqueue the job
                backgroundJobClient.Enqueue<BackgroundJobService>(service =>
                    service.ProcessExcelAndPlaceOrders(excelFilePath));

                return Results.Ok("Job has been enqueued.");
            });

            app.Run();
        }
    }
}
