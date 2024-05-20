using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.EventService.Domain.Entity;

namespace NstuOnline.EventService.Infrastructure.Database.EntityConfigurations;

public class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
{
    public void Configure(EntityTypeBuilder<Attachment> builder)
    {
        builder.ToTable("attachment");
        
        builder
            .HasKey(x => x.Id);
        
        builder
            .HasOne(x => x.AttachmentType)
            .WithMany()
            .HasForeignKey(x => x.AttachmentTypeId);
    }
}