using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.EducationalStructure.Domain.Entity;

namespace NstuOnline.EducationalStructure.Infrastructure.Database.EntityConfigurations;

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
            .WithMany()
            .HasForeignKey(x => x.AttachmentId);
    }
}