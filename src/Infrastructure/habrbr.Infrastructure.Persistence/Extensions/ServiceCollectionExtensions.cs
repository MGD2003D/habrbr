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

namespace Habrbr.Infrastructure.Persistence.Extensions
{
    public static class RepositoryCollectionExtensions
    {
        public static IServiceCollection AddInfrastructurePersistence(this IServiceCollection collection, IConfiguration configuration)
        {
            AddConnection(collection, configuration);

            collection.AddScoped<IArticleRepository, ArticleRepository>();
            collection.AddScoped<IBlogRepository, BlogRepository>();
            collection.AddScoped<ICommentRepository, CommentRepository>();
            collection.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            collection.AddScoped<IUserRepository, UserRepository>();
            collection.AddScoped<IUserRightsInBlogRepository, UserRightsInBlogRepository>();

            return collection;
        }

        public static IServiceCollection AddConnection(this IServiceCollection collection, IConfiguration configuration)
        {
            collection.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetSection("Infrastructure:Persistence:Postgres:ConnectionString").Value));
            return collection;
        }
    }
}