using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.EducationalStructure.Domain.Entity;

namespace NstuOnline.EducationalStructure.Infrastructure.Database.EntityConfigurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("department");
        
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);
        
        builder
            .HasIndex(x => x.Name)
            .IsUnique();

        builder
            .HasOne(x => x.Faculty)
            .WithMany()
            .HasForeignKey(x => x.FacultyId);
        
        builder
            .Property(x => x.ExternalId)
            .HasMaxLength(50);
        
        builder
            .HasIndex(x => x.ExternalId)
            .IsUnique();
    }
}