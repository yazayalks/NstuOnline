using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NstuOnline.PortfolioService.Infrastructure.Database;

public class PortfolioContextFactory : IDesignTimeDbContextFactory<PortfolioContext>
{
    public PortfolioContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PortfolioContext>();
        optionsBuilder.UseNpgsql("User ID=postgres;Password=6969;Host=localhost;Port=5433;Database=NstuOnlinePortfolioDb;");

        return new PortfolioContext(optionsBuilder.Options);
    }
}