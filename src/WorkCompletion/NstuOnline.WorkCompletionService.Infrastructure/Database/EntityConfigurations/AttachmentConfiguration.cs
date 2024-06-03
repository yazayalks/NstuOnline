using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.WorkCompletion.Domain.Entity;

namespace NstuOnline.WorkCompletion.Infrastructure.Database.EntityConfigurations;

public class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
{
    public void Configure(EntityTypeBuilder<Attachment> builder)
    {
        builder.ToTable("attachment");

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