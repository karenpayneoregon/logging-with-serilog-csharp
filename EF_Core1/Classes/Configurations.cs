namespace EF_Core1.Classes;

public class Configurations
{
    public static IConfigurationRoot GetConfigurationRoot()
    {
        return new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
    }
}
