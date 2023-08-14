﻿namespace Xo.Core.Extensions;

public static class ConfigurationExtensions
{
    public static IConfiguration AddConfigurations(this IServiceCollection @this,
        in IEnumerable<string>? configurations = null
    )
    {
        var configurationBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        if (configurations is null)
        {
            return @this.AddConfiguration(configurationBuilder.Build());
        }

        foreach (var config in configurations)
        {
            configurationBuilder.AddJsonFile(config, optional: false, reloadOnChange: true);
        }

        return @this.AddConfiguration(configurationBuilder.Build());
    }

    public static IConfiguration AddConfiguration(this IServiceCollection @this,
        in IConfigurationRoot configuration
    )
    {
        @this.AddSingleton<IConfiguration>(configuration);
        return configuration;
    }
}
