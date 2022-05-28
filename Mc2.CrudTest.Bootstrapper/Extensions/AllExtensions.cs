using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Mc2.CrudTest.Bootstrapper.Extensions;

public static class AllExtensions
{
    public static void InitAutofac(this IHostBuilder hostBuilder) { }

    public static void AddTableNameMapper(this IServiceCollection _)
    {

    }

    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var cnn = configuration.GetConnectionString("DefaultConnection");

        return services;
    }

    public static IServiceCollection AddDIContainerBuilder(this IServiceCollection services, IHostBuilder hostBuilder)
    {

        return services;
    }

    public static IServiceCollection AddAutoMapper(this IServiceCollection services) => services;

    public static IServiceCollection AddMediatR(this IServiceCollection services)
    {

        return services;
    }

    public static IServiceCollection AddFluentValidation(this IServiceCollection services)
    {

        return services;
    }

    public static IServiceCollection AddSwagger(this IServiceCollection services) =>
        services.AddEndpointsApiExplorer().AddSwaggerGen();

    public static IApplicationBuilder UseSwagger(this IApplicationBuilder app) =>
        app.UseSwagger().UseSwaggerUI();

    public static IApplicationBuilder IntializeDatabase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

        return app;
    }
}