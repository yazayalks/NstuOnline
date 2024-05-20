using Microsoft.EntityFrameworkCore;

namespace NstuOnline.PortfolioService.Infrastructure.Database;

public class PortfolioContext : DbContext
{
    public PortfolioContext(DbContextOptions<PortfolioContext> options)
        : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PortfolioContext).Assembly);
    }
}