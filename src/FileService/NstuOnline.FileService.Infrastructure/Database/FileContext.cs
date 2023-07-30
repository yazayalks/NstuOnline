using Microsoft.EntityFrameworkCore;

namespace NstuOnline.FileService.Infrastructure.Database;

public class FileContext : DbContext
{
    public FileContext(DbContextOptions<FileContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FileContext).Assembly);
    }
}