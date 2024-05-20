using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NstuOnline.AlbumService.Infrastructure.Database;

public class AlbumContextFactory : IDesignTimeDbContextFactory<AlbumContext>
{
    public AlbumContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AlbumContext>();
        optionsBuilder.UseNpgsql("User ID=postgres;Password=6969;Host=localhost;Port=5433;Database=NstuOnlineAlbumDb;");

        return new AlbumContext(optionsBuilder.Options);
    }
}