using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.PortfolioService.Domain.Entity;

namespace NstuOnline.PortfolioService.Infrastructure.Database.EntityConfigurations;

public class TopicAttachmentConfiguration : IEntityTypeConfiguration<TopicAttachment>
{
    public void Configure(EntityTypeBuilder<TopicAttachment> builder)
    {
        builder.ToTable("topic_attachment");
        
        builder
            .HasKey(x => new { x.TopicId, x.AttachmentId });

        builder
            .HasOne(x => x.Topic)
            .WithMany(x => x.Attachments)
            .HasForeignKey(x => x.TopicId);
        
        builder
            .HasOne(x => x.Attachment)
            .WithMany(x => x.Topics)
            .HasForeignKey(x => x.AttachmentId);
    }
}