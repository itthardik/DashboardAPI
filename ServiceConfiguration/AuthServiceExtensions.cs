using Dashboard.Utility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Dashboard.ServiceConfiguration
{
    /// <summary>
    /// Extension methods for configuring authentication and authorization services.
    /// </summary>
    public static class AuthServiceExtensions
    {
        /// <summary>
        /// Configures JWT authentication and role-based authorization policies.
        /// </summary>
        /// <param name="services">The service collection to which authentication and authorization will be added.</param>
        /// <param name="configuration">The configuration object used to retrieve JWT settings.</param>
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection AddCustomAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
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
                        Console.WriteLine("\n"+ context.Request.Cookies + "\n");
                        var token = context.Request.Cookies["jwtToken"];
                        if (!string.IsNullOrEmpty(token))
                        {
                            context.Token = token;
                        }
                        return Task.CompletedTask;
                    }
                };
            });

            // Configure role-based authorization policies
            services.AddAuthorizationBuilder()
                .AddPolicy("FullAccessPolicy", policy =>
                    policy.RequireRole("admin"))
                .AddPolicy("SalesAccessPolicy", policy =>
                    policy.RequireRole("sales", "admin"))
                .AddPolicy("RevenueAccessPolicy", policy =>
                    policy.RequireRole("revenue", "admin"))
                .AddPolicy("InventoryAccessPolicy", policy =>
                    policy.RequireRole("inventory", "admin"))
                .AddPolicy("CustomerSupportAccessPolicy", policy =>
                    policy.RequireRole("support", "admin"))
                .AddPolicy("Inventory&RevenueAccessPolicy", policy =>
                    policy.RequireRole("inventory", "revenue", "admin"));

            return services;
        }
    }
}
