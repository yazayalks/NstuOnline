using Microsoft.EntityFrameworkCore;

namespace NstuOnline.AlbumService.Infrastructure.Database;

public class AlbumContext : DbContext
{
    public AlbumContext(DbContextOptions<AlbumContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AlbumContext).Assembly);
    }
}