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
using habrbr.Infrastructure.Persistence.Repositories;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructurePersistence(this IServiceCollection collection)
    {
        collection.AddPlatformPostgres(builder => builder.BindConfiguration("Infrastructure:Persistence:Postgres"));
        collection.AddSingleton<IDataSourcePlugin, MappingPlugin>();

        collection.AddPlatformMigrations(typeof(IAssemblyMarker).Assembly);
        collection.AddHostedService<MigrationRunnerService>();

        // TODO: add repositories
        collection.AddScoped<IArticleRepository, ArticleRepository>();
        collection.AddScoped<IBlogRepository, BlogRepository>();
        collection.AddScoped<ICommentRepository, CommentRepository>();
        collection.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
        collection.AddScoped<IUserRepository, UserRepository>();
        collection.AddScoped<IUserRightsInBlogRepository, UserRightsInBlogRepository>();
        
        collection.AddScoped<IPersistenceContext, PersistenceContext>();

		collection.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        return collection;
    }
    public static IServiceCollection AddInfrastructurePersistence(this IServiceCollection collection, IConfiguration configuration)
    {
        collection.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        return collection;
    }
}