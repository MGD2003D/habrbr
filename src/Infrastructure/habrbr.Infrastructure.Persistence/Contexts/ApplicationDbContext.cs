using Microsoft.EntityFrameworkCore;

namespace habrbr.Infrastructure.Persistence.Contexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() {}
    public ApplicationDbContext(DbContextOptions options) : base(options) { }
    public required DbSet<Article> Article { get; set; }
    public required DbSet<Blog> Blog { get; set; }
    public required DbSet<Comment> Comment { get; set; }
    public required DbSet<Subscription> Subscription { get; set; }
    public required DbSet<User> User { get; set; }
    public required DbSet<UserRightsInBlog> UserRightsInBlog { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}