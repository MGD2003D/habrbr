using Microsoft.EntityFrameworkCore;
using Models;

namespace habrbr.Infrastructure.Persistence.Contexts;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext() {}

	public ApplicationDbContext(DbContextOptions options) : base(options) { }

	required public DbSet<User> Users { get; set; }
	public DbSet<UserRightsInBlog> UserRightsInBlogs { get; set; }
	public DbSet<Blog> Blogs { get; set; }
	public DbSet<Comment> Comments { get; set; }
	public DbSet<Subscription> Subscriptions { get; set; }
	public DbSet<Article> Articles { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
		modelBuilder.ApplyConfiguration(new UserConfiguration());
		base.OnModelCreating(modelBuilder);
    }
}