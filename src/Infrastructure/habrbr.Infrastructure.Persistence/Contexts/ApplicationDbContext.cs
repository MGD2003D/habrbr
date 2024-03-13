using Microsoft.EntityFrameworkCore;
using Models;

namespace habrbr.Infrastructure.Persistence.Contexts;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext() {}

	public ApplicationDbContext(DbContextOptions options) : base(options) { }

	required public DbSet<User> User { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
		modelBuilder.ApplyConfiguration(new UserConfiguration());
		base.OnModelCreating(modelBuilder);
    }
}