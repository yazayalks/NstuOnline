using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.EducationalStructure.Domain.Entity;

namespace NstuOnline.EducationalStructure.Infrastructure.Database.EntityConfigurations;

public class FlowConfiguration : IEntityTypeConfiguration<Flow>
{
    public void Configure(EntityTypeBuilder<Flow> builder)
    {
        builder.ToTable("flow");
        
        builder
            .HasKey(x => x.Id);
        
        builder
            .Property(x => x.ExternalId)
            .HasMaxLength(50);
        
        builder
            .HasIndex(x => x.ExternalId)
            .IsUnique();
    }
}