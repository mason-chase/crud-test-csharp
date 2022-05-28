using Autofac;
using Autofac.Extensions.DependencyInjection;
using Dapper.Contrib.Extensions;
using FluentValidation;
using Mc2.CrudTest.Bootstrapper.Modules;
using Mc2.CrudTest.Data.EF.DatabaseContext;
using Mc2.CrudTest.Data.EF.Repositories.Concretes;
using Mc2.CrudTest.Data.EF.Repositories.Interfaces;
using Mc2.CrudTest.Data.Shared.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace Mc2.CrudTest.Bootstrapper.Extensions;

public static class AllExtensions
{
    public static void InitAutofac(this IHostBuilder hostBuilder) =>
        hostBuilder.UseServiceProviderFactory(new AutofacServiceProviderFactory());

    public static void AddTableNameMapper(this IServiceCollection _)
    {
        SqlMapperExtensions.TableNameMapper = entityType =>
        {
            var getNames = TableMappingName.GetNames();

            var getTable = getNames.FirstOrDefault(_ => _.Name.Equals(entityType.Name, StringComparison.CurrentCulture));

            if (getTable is null) throw new Exception($"Not supported entity type {entityType} .. !!!!");

            var result = $"{getTable.SchemaName}.{getTable.PluralName}";

            return result;
        };
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var cnn = configuration.GetConnectionString("DefaultConnection");

        return services
            .AddDbContextPool<AppDbContext>(_ =>
                _.UseInMemoryDatabase(cnn)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            )
        ;
    }

    public static IServiceCollection AddDIContainerBuilder(this IServiceCollection services, IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new MyApplicationModule()));

        return services.AddScoped(typeof(IEFRepository<>), typeof(EFRepository<>));
    }

    public static IServiceCollection AddAutoMapper(this IServiceCollection services) =>
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

    public static IServiceCollection AddMediatR(this IServiceCollection services)
    {

        return services;
    }

    public static IServiceCollection AddFluentValidation(this IServiceCollection services)
    {
        //services.AddScoped<IValidator<CreateCustomerDTO>>(x => 
        //    new CreateCustomerDTOValidator(x.GetRequiredService<ICustomerService>()));

        return services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public static IServiceCollection AddSwagger(this IServiceCollection services) =>
        services.AddEndpointsApiExplorer().AddSwaggerGen();

    public static IApplicationBuilder UseSwagger(this IApplicationBuilder app) =>
        app.UseSwagger().UseSwaggerUI();

    public static IApplicationBuilder IntializeDatabase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        dbContext.Database.EnsureCreated();

        //var dataInitializer = scope.ServiceProvider.GetRequiredService<IDataInitializer>();
        //dataInitializer.InitializeDataAsync().GetAwaiter().GetResult();

        return app;
    }
}