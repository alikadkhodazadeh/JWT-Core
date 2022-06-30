using Microsoft.Extensions.Configuration;

namespace Portal.Infrastructure.Persistence;

public class ContextFactory : IContextFactory<Context>
{
    private readonly IConfiguration _configuration;

    public ContextFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Context CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<Context>()
            .UseSqlite(_configuration.GetConnectionString("Context"))
            .Options;
        return new Context(options);
    }
}