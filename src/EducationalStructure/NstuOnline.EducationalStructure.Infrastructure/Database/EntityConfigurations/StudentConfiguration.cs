using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.EducationalStructure.Domain.Entity;

namespace NstuOnline.EducationalStructure.Infrastructure.Database.EntityConfigurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("student");
        
        builder
            .HasKey(x => x.Id);
        
        builder
            .HasIndex(x => x.UserId)
            .IsUnique();

        builder
            .HasOne(x => x.Syllabus)
            .WithMany()
            .HasForeignKey(x => x.SyllabusId);
        
        builder
            .HasOne(x => x.Group)
            .WithMany()
            .HasForeignKey(x => x.GroupId);
    }
}