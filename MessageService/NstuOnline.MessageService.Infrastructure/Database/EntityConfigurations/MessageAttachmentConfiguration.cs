using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.MessageService.Domain.Entities;

namespace NstuOnline.MessageService.Infrastructure.Database.EntityConfigurations;

public class MessageAttachmentConfiguration : IEntityTypeConfiguration<MessageAttachment>
{
    public void Configure(EntityTypeBuilder<MessageAttachment> builder)
    {
        builder.ToTable("message_attachment");
        
        builder
            .HasKey(x => new { x.MessageId, x.AttachmentId });

        builder
            .HasOne(x => x.Message)
            .WithMany()
            .HasForeignKey(x => x.MessageId);
        
        builder
            .HasOne(x => x.Attachment)
            .WithMany()
            .HasForeignKey(x => x.AttachmentId);

        // builder
        //     .HasOne(x => x.Message)
        //     .WithMany(x => x.MessageAttachments)
        //     .HasForeignKey(x => x.MessageId);
        //
        // builder
        //     .HasOne(x => x.Attachment)
        //     .WithMany(x => x.MessageAttachments)
        //     .HasForeignKey(x => x.AttachmentId);
    }
}