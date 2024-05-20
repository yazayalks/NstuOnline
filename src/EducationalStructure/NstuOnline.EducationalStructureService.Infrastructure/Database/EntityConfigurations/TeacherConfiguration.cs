using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.EducationalStructure.Domain.Entity;

namespace NstuOnline.EducationalStructure.Infrastructure.Database.EntityConfigurations;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.ToTable("teacher");
        
        builder
            .HasKey(x => x.Id);
        
        builder
            .HasIndex(x => x.UserId)
            .IsUnique();

        builder
            .HasOne(x => x.Department)
            .WithMany()
            .HasForeignKey(x => x.DepartmentId);
    }
}