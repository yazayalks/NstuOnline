using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NstuOnline.EducationalStructure.Infrastructure.Database;

public class EducationalStructureContextFactory : IDesignTimeDbContextFactory<EducationalStructureContext>
{
    public EducationalStructureContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EducationalStructureContext>();
        optionsBuilder.UseNpgsql("User ID=postgres;Password=6969;Host=localhost;Port=5433;Database=NstuOnlineEducationalStructureDb;");

        return new EducationalStructureContext(optionsBuilder.Options);
    }
}