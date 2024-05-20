using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.EducationalStructure.Domain.Entity;

namespace NstuOnline.EducationalStructure.Infrastructure.Database.EntityConfigurations;

public class StudyLevelConfiguration : IEntityTypeConfiguration<StudyLevel>
{
    public void Configure(EntityTypeBuilder<StudyLevel> builder)
    {
        builder.ToTable("study_level");
        
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);
        
        builder
            .Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .HasIndex(x => x.Name)
            .IsUnique();
        
        builder
            .HasIndex(x => x.Code)
            .IsUnique();
    }
}