using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.WorkCompletion.Domain.Entity;

namespace NstuOnline.WorkCompletion.Infrastructure.Database.EntityConfigurations;

public class WorkConfiguration : IEntityTypeConfiguration<Work>
{
    public void Configure(EntityTypeBuilder<Work> builder)
    {
        builder.ToTable("work");
        
        builder
            .HasKey(x => x.Id);
    
        builder
            .Property(x => x.Name)
            .HasMaxLength(100);
        
        builder
            .Property(x => x.Description)
            .HasMaxLength(500);

        builder
            .HasMany(x => x.Attachments)
            .WithOne();
        
        builder
            .Property(x => x.ExternalId)
            .HasMaxLength(50);
        
        builder
            .HasIndex(x => x.ExternalId)
            .IsUnique();
    }
}