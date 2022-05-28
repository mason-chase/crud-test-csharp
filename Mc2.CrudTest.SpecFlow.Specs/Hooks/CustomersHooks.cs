using BoDi;
using Mc2.CrudTest.Presentation.Front;
using Mc2.CrudTest.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Mc2.CrudTest.SpecFlow.Specs.Hooks;

[Binding]
public sealed class CustomersHooks
{
    private const string AppSettingsFile = "appsettings.json";

    private readonly IObjectContainer _objectContainer;

    private static IHost _host;

    [BeforeTestRun]
    public static async Task BeforeTestRun()
    {
        //_host = Program.CreateHostBuilder(null).Build();

        var builder = WebApplication.CreateBuilder();

        _host = builder.Build();

        await _host.StartAsync();
    }

    [AfterTestRun]
    public static Task AfterTestRun() => _host.StopAsync();

    [BeforeScenario]
    public async Task RegisterServices()
    {
        var factory = GetWebApplicationFactory();
        await ClearData(factory);
        _objectContainer.RegisterInstanceAs(factory);
        var repository = (ICustomerService)factory.Services.GetService(typeof(ICustomerService))!;
        _objectContainer.RegisterInstanceAs(repository);
    }

    private WebApplicationFactory<Program> GetWebApplicationFactory() =>
        new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                //IConfigurationSection? configSection = null;
                builder.ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), AppSettingsFile));
                    //configSection = context.Configuration.GetSection("");
                });
                //builder.ConfigureTestServices(services => services.Configure<string>(configSection));
            });

    private static async Task ClearData(WebApplicationFactory<Program> factory)
    {
        if (factory.Services.GetService(typeof(ICustomerService))
            is not ICustomerService customerService) return;

        var entities = await customerService.GetAllAsync();

        foreach (var entity in entities)
            await customerService.DeleteAsync(entity, default, true);
    }
}
