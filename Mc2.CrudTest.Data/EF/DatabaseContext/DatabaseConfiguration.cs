using Microsoft.Extensions.Configuration;

public class DatabaseConfiguration : ConfigurationBase
{
    private const string DefaultConnection = nameof(DefaultConnection);
    public string GetDataConnectionString() => GetConfiguration().GetConnectionString(DefaultConnection);
}