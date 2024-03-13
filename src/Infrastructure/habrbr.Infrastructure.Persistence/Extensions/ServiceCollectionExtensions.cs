namespace Habrbr.Infrastructure.Persistence.Extensions;

using Microsoft.EntityFrameworkCore;
using Habrbr.Application.Abstractions.Persistence;
using Habrbr.Infrastructure.Persistence.Migrations;
using Habrbr.Infrastructure.Persistence.Plugins;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.Dev.Platform.Postgres.Plugins;
using habrbr.Infrastructure.Persistence.Contexts;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructurePersistence(this IServiceCollection collection)
    {
        collection.AddPlatformPostgres(builder => builder.BindConfiguration("Infrastructure:Persistence:Postgres"));
        collection.AddSingleton<IDataSourcePlugin, MappingPlugin>();

        collection.AddPlatformMigrations(typeof(IAssemblyMarker).Assembly);
        collection.AddHostedService<MigrationRunnerService>();

        // TODO: add repositories
        collection.AddScoped<IPersistenceContext, PersistenceContext>();

        return collection;
    }
    public static IServiceCollection AddInfrastructurePersistence(this IServiceCollection collection, IConfiguration configuration)
    {
        collection.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetSection("Infrastructure:Persistence:Postgres:ConnectionString").Value));
        return collection;
    }
}