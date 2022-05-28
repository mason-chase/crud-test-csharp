using Mc2.CrudTest.Bootstrapper.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Mc2.CrudTest.Bootstrapper.Startup;

public static class AllRegisterForStartup
{
    public static IServiceCollection AddConfigureServices(this IServiceCollection services, IHostBuilder hostBuilder, IConfiguration configuration)
    {
        hostBuilder.InitAutofac();

        services.AddTableNameMapper();

        return services
            .AddPersistence(configuration)
            .AddSwagger()
            .AddAutoMapper()
            .AddMediatR()
            .AddFluentValidation()
            .AddDIContainerBuilder(hostBuilder)
        ;
    }

    public static IApplicationBuilder UseConfigure(this IApplicationBuilder app, IHostEnvironment env, IConfiguration configuration)
    {
        app
            .IntializeDatabase()
            .UseSwagger()
        ;

        return app;
    }
}