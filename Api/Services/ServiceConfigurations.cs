using System.Configuration;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Api.Data;
using Api.Data.Repositories;
using Api.Entities;
using Api.Services.DataServices;

namespace Api.Services;

public static class ServiceConfigurations
{
    /// <summary>
    /// Configure IIS settings for our application
    /// </summary>
    /// <param name="services">The WebApplicationBuilder's Service Collection</param>
    public static void ConfigureIis(this IServiceCollection services)
    {
        services.Configure<IISOptions>(_ =>
        {
            /* change nothing, keep default options */
        });
    }

    /// <summary>
    /// Configure CORS settings for our application.
    /// </summary>
    /// <param name="services">The WebApplicationBuilder's Service Collection</param>
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(opt => opt.AddPolicy("CorsPolicy", policy =>
        {
            // TODO update cors policy
            policy.AllowAnyOrigin();
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
        }));
    }

    /// <summary>
    /// Configure the Data Repository settings, and the Data Service Manager for the project
    /// </summary>
    /// <param name="services">The WebApplicationBuilder's Service Collection</param>
    public static void ConfigureDataServices(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryManager, RepositoryManager>();
        services.AddScoped<IDataServiceManager, DataServiceManager>();
    }

    public static void ConfigureIdentity(this IServiceCollection services)
    {
        services.AddIdentity<User, UserRole>(opt =>
            {
                opt.Password.RequireDigit = true;
                opt.Password.RequiredLength = 8;
                opt.Password.RequireLowercase = true;
                opt.User.RequireUniqueEmail = true;
                opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_";
            }).AddEntityFrameworkStores<NorthwindContext>()
            .AddDefaultTokenProviders();
    }

    public static void ConfigureJwtService(this IServiceCollection services, IConfiguration jwtConfig)
    {
        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(opt =>
        {
            opt.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = jwtConfig["ValidIssuer"],
                ValidAudience = jwtConfig["ValidAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig["JwtSecret"]!))
            };
        });

        services.AddAuthorization();
    }
}