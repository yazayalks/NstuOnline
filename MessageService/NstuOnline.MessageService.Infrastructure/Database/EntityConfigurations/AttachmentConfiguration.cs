using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.MessageService.Domain.Entities;

namespace NstuOnline.MessageService.Infrastructure.Database.EntityConfigurations;

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
        
        builder
            .HasMany(x => x.Messages)
            .WithMany(x => x.Attachments)
            .UsingEntity<MessageAttachment>();
    }
}