using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using habrbr.Infrastructure.Persistence.Contexts;
using Models;
// using habrbr.Application.Contracts;

namespace habrbr.Infrastructure.Persistence.Contexts;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.ID);

        builder.Property(u => u.UserName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Password)
            .IsRequired();

        builder.Property(u => u.RegistrationDate)
            .IsRequired();
    }
}
