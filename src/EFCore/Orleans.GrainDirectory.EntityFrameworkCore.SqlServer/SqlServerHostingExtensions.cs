using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Orleans.GrainDirectory.EntityFrameworkCore;
using Orleans.GrainDirectory.EntityFrameworkCore.SqlServer.Data;
using Orleans.Hosting;
using Orleans.Runtime;

namespace Orleans.GrainDirectory;

public static class SqlServerHostingExtensions
{
    public static ISiloBuilder UseEntityFrameworkCoreSqlServerGrainDirectoryAsDefault(
        this ISiloBuilder builder,
        Action<DbContextOptionsBuilder> configureDatabase)
    {
        return builder.ConfigureServices(services => services.AddEntityFrameworkCoreSqlServerGrainDirectory(GrainDirectoryAttribute.DEFAULT_GRAIN_DIRECTORY, configureDatabase));
    }

    public static ISiloBuilder UseEntityFrameworkCoreSqlServerGrainDirectoryAsDefault(
        this ISiloBuilder builder)
    {
        return builder.ConfigureServices(services => services.AddEntityFrameworkCoreSqlServerGrainDirectory(GrainDirectoryAttribute.DEFAULT_GRAIN_DIRECTORY));
    }

    public static ISiloBuilder AddEntityFrameworkCoreSqlServerGrainDirectory(
        this ISiloBuilder builder,
        string name,
        Action<DbContextOptionsBuilder> configureDatabase)
    {
        return builder.ConfigureServices(services => services.AddEntityFrameworkCoreSqlServerGrainDirectory(name, configureDatabase));
    }

    public static ISiloBuilder AddEntityFrameworkCoreSqlServerGrainDirectory(
        this ISiloBuilder builder,
        string name)
    {
        return builder.ConfigureServices(services => services.AddEntityFrameworkCoreSqlServerGrainDirectory(name));
    }

    internal static IServiceCollection AddEntityFrameworkCoreSqlServerGrainDirectory(
        this IServiceCollection services,
        string name,
        Action<DbContextOptionsBuilder> configureDatabase)
    {
        services
            .AddPooledDbContextFactory<SqlServerGrainDirectoryDbContext>(configureDatabase)
            .AddEntityFrameworkCoreSqlServerGrainDirectory(name);

        return services;
    }

    internal static IServiceCollection AddEntityFrameworkCoreSqlServerGrainDirectory(
        this IServiceCollection services,
        string name)
    {
        services
            .AddSingleton<IEFGrainDirectoryETagConverter<byte[]>, SqlServerGrainDirectoryETagConverter>()
            .AddKeyedSingleton<IGrainDirectory>(name, (sp, _) => ActivatorUtilities.CreateInstance<EFCoreGrainDirectory<SqlServerGrainDirectoryDbContext, byte[]>>(sp))
            .AddKeyedSingleton<ILifecycleParticipant<ISiloLifecycle>>(name, (s, n) => (ILifecycleParticipant<ISiloLifecycle>)s.GetKeyedServices<IGrainDirectory>(n));

        return services;
    }
}