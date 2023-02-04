using Microsoft.Extensions.Configuration;

namespace SqlServerSink.Classes;
public class Configurations
{
    public static IConfigurationRoot GetConfigurationRoot() =>
        new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
}
