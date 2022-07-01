using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portal.Infrastructure.Persistence.Configs;

internal class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasKey(k => k.Id);

        builder
            .Property(u => u.FirstName)
            .HasMaxLength(50)
            .IsRequired();
        builder
            .Property(u => u.LastName)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(u => u.Email)
            .HasMaxLength(150)
            .IsRequired();
        builder
            .HasIndex(u => u.Email)
            .IsUnique();

        builder
            .Property(u => u.PasswordHash)
            .HasMaxLength(90)
            .IsRequired();

        List<User> users = new()
        {
            new User("Jack","Ma","jackma@example.com","jack123"){ Role = Role.Admin },
            new User("Bob","Rezvani","bobrezvani@example.com","bob123"),
            new User("John","Smith","johnsmith@example.com","john123"),
        };

        builder.HasData(users);
    }
}
