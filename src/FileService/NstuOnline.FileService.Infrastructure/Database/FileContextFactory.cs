using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NstuOnline.FileService.Infrastructure.Database;

public class FileContextFactory : IDesignTimeDbContextFactory<FileContext>
{
    public FileContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<FileContext>();
        optionsBuilder.UseNpgsql("User ID=postgres;Password=6969;Host=localhost;Port=5433;Database=NstuOnlineFileServiceDb;");

        return new FileContext(optionsBuilder.Options);
    }
}