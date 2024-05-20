using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.WallService.Domain.Entity;

namespace NstuOnline.WallService.Infrastructure.Database.EntityConfigurations;

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
        
        builder
            .HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId);
    }
}