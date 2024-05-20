using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.WallService.Domain.Entity;

namespace NstuOnline.WallService.Infrastructure.Database.EntityConfigurations;

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