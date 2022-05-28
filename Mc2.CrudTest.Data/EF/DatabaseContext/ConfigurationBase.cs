using Microsoft.Extensions.Configuration;

public abstract class ConfigurationBase
{
    protected IConfigurationRoot GetConfiguration()
    {
        return new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
           .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? ""}.json", optional: true, reloadOnChange: true)
           .AddEnvironmentVariables()
           .AddCommandLine(new string[] { "SinjulMSBH", "Mc2" })
           .Build();
    }

    protected void RaiseValueNotFoundException(string configurationKey) => throw new Exception($"appsettings key ({configurationKey}) could not be found .. !!!!");
}