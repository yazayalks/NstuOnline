using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.EducationalStructure.Domain.Entity;

namespace NstuOnline.EducationalStructure.Infrastructure.Database.EntityConfigurations;

public class SyllabusSubjectConfiguration : IEntityTypeConfiguration<SyllabusSubject>
{
    public void Configure(EntityTypeBuilder<SyllabusSubject> builder)
    {
        builder.ToTable("syllabus_subject");

        builder
            .HasKey(x => new { x.SubjectId, x.SyllabusId });
        
        builder
            .HasOne(x => x.Subject)
            .WithMany()
            .HasForeignKey(x => x.SubjectId);
        
        builder
            .HasOne(x => x.Syllabus)
            .WithMany()
            .HasForeignKey(x => x.SyllabusId);
        
        builder
            .Property(x => x.ExternalId)
            .HasMaxLength(50);
        
        builder
            .HasIndex(x => x.ExternalId)
            .IsUnique();
    }
}