using Microsoft.EntityFrameworkCore;

public interface IContext
{
    DbSet<User> Users { get; set; }
    DbSet<RefreshToken> RefreshTokens { get; set; }
    Task<OperationResult> SaveAsync(CancellationToken cancellationToken);
}
