using Microsoft.EntityFrameworkCore;

namespace NstuOnline.EducationalStructure.Infrastructure.Database;

public class EducationalStructureContext : DbContext
{
    public EducationalStructureContext(DbContextOptions<EducationalStructureContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EducationalStructureContext).Assembly);
    }
}