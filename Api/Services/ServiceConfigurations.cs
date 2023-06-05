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
}
