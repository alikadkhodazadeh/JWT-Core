namespace Portal.Infrastructure.Persistence;

public class Context : DbContext, IContext
{
    public Context(DbContextOptions<Context> options)
        : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }

    public async Task<OperationResult> SaveAsync(CancellationToken cancellationToken)
    {
        try
        {
            await SaveChangesAsync(cancellationToken);
            return OperationResult.Success();
        }
        catch (Exception)
        {
            return OperationResult.Fail();
        }
    }
}
