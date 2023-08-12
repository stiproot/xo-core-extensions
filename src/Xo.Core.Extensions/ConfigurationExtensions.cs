namespace Xo.Core.Extensions;

public static class ConfigurationExtensions
{
    public static IConfiguration AddConfiguration(this IServiceCollection @this)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        @this.AddSingleton<IConfiguration>(configuration);

        return configuration;
    }
}
