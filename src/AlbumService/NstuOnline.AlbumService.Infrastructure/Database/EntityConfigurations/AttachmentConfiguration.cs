using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NstuOnline.AlbumService.Domain.Entity;

namespace NstuOnline.AlbumService.Infrastructure.Database.EntityConfigurations;

public class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
{
    public void Configure(EntityTypeBuilder<Attachment> builder)
    {
        builder.ToTable("attachment");

        builder
            .HasKey(x => x.Id);
    }
}