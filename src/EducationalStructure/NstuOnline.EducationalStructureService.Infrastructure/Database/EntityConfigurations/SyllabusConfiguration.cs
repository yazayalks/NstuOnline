using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.EducationalStructure.Domain.Entity;

namespace NstuOnline.EducationalStructure.Infrastructure.Database.EntityConfigurations;

public class SyllabusConfiguration : IEntityTypeConfiguration<Syllabus>
{
    public void Configure(EntityTypeBuilder<Syllabus> builder)
    {
        builder.ToTable("syllabus");
        
        builder
            .HasKey(x => x.Id);
        
        builder
            .HasOne(x => x.Specialization)
            .WithMany()
            .HasForeignKey(x => x.SpecializationId);
        
        builder
            .HasOne(x => x.StudyFormType)
            .WithMany()
            .HasForeignKey(x => x.StudyFormTypeId);
        
        builder
            .HasOne(x => x.AccreditationType)
            .WithMany()
            .HasForeignKey(x => x.AccreditationTypeId);
        
        builder
            .HasOne(x => x.StudyLevel)
            .WithMany()
            .HasForeignKey(x => x.StudyLevelId);
    }
}