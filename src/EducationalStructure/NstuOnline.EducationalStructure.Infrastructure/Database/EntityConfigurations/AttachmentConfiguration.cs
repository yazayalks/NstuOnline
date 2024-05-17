using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.EducationalStructure.Domain.Entity;

namespace NstuOnline.EducationalStructure.Infrastructure.Database.EntityConfigurations;

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
            .HasMany(x => x.Topics)
            .WithMany(x => x.Attachments)
            .UsingEntity<TopicAttachment>();
    }
}