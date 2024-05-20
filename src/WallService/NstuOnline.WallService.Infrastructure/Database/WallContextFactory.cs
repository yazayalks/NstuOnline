using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NstuOnline.WallService.Infrastructure.Database;

public class WallContextFactory : IDesignTimeDbContextFactory<WallContext>
{
    public WallContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<WallContext>();
        optionsBuilder.UseNpgsql("User ID=postgres;Password=6969;Host=localhost;Port=5433;Database=NstuOnlineWallDb;");

        return new WallContext(optionsBuilder.Options);
    }
}