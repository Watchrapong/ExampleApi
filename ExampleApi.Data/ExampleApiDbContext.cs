using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace ExampleApi.Data;

public class ExampleApiDbContext : DbContext
{
    // public ExampleApiDbContext(){}
    public ExampleApiDbContext(DbContextOptions<ExampleApiDbContext> options) : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
#if DEBUG
            optionsBuilder.UseSqlServer("Server=localhost;Database=ExampleApiDB;User ID=sa;Password=P@ssw0rd1234;TrustServerCertificate=true");
#else
            throw new Exception("Please enter ExampleApiConn in appsettings.json file");
#endif
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}