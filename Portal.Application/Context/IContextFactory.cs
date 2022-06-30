using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public interface IContextFactory<TContext> : IDesignTimeDbContextFactory<TContext> where TContext : DbContext
{
}