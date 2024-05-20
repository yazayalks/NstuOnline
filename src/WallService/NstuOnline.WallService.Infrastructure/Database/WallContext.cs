using Microsoft.EntityFrameworkCore;

namespace NstuOnline.WallService.Infrastructure.Database;

public class WallContext : DbContext
{
    public WallContext(DbContextOptions<WallContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WallContext).Assembly);
    }
}