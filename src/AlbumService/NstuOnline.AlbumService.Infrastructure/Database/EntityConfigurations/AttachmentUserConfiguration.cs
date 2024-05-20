using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.AlbumService.Domain.Entity;

namespace NstuOnline.AlbumService.Infrastructure.Database.EntityConfigurations;

public class AttachmentUserConfiguration : IEntityTypeConfiguration<AttachmentUser>
{
    public void Configure(EntityTypeBuilder<AttachmentUser> builder)
    {
        builder.ToTable("attachment_user");
        
        builder
            .HasKey(x => new { x.AttachmentId, x.UserId });

        builder
            .HasOne(x => x.Attachment)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.AttachmentId);
    }
}