using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portal.Infrastructure.Persistence.Configs;

internal class RefreshTokenConfig : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder
            .HasKey(k => k.UserId);

        builder
            .Property(r => r.Token)
            .IsRequired();

        builder
            .HasOne(p => p.User)
            .WithMany(t => t.RefreshTokens)
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
