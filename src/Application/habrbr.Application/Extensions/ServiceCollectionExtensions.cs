using habrbr.Application.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Habrbr.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IArticleService, ArticleService>();
        collection.AddScoped<IBlogService, BlogService>();
        collection.AddScoped<ICommentService, CommentService>();
        collection.AddScoped<ISubscriptionService, SubscriptionService>();
        collection.AddScoped<IUserRightsInBlogService, UserRightsInBlogService>();
        collection.AddScoped<IUserService, UserService>();
        return collection;
    }
}