using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.WallService.Domain.Entity;

namespace NstuOnline.WallService.Infrastructure.Database.EntityConfigurations;

public class RecordAttachmentConfiguration : IEntityTypeConfiguration<RecordAttachment>
{
    public void Configure(EntityTypeBuilder<RecordAttachment> builder)
    {
        builder.ToTable("record_attachment");

        builder
            .HasKey(ra => new { ra.RecordId, ra.AttachmentId });

        builder
            .HasOne(ra => ra.Record)
            .WithMany(r => r.Attachments)
            .HasForeignKey(ra => ra.RecordId);

        builder
            .HasOne(ra => ra.Attachment)
            .WithMany(a => a.Records)
            .HasForeignKey(ra => ra.AttachmentId);
    }
}