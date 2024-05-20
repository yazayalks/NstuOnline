using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.EducationalStructure.Domain.Entity;

namespace NstuOnline.EducationalStructure.Infrastructure.Database.EntityConfigurations;

public class TeachingAssignmentConfiguration : IEntityTypeConfiguration<TeachingAssignment>
{
    public void Configure(EntityTypeBuilder<TeachingAssignment> builder)
    {
        builder.ToTable("teaching_assignment");

        builder
            .HasKey(x => new { x.SubjectId, x.TeacherId, x.GroupId });

        builder
            .HasOne(x => x.Subject)
            .WithMany()
            .HasForeignKey(x => x.SubjectId);

        builder
            .HasOne(x => x.Teacher)
            .WithMany()
            .HasForeignKey(x => x.TeacherId);

        builder
            .HasOne(x => x.Group)
            .WithMany()
            .HasForeignKey(x => x.GroupId);
    }
}